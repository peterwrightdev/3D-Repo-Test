using LitJson;
using System;
using System.IO;
using System.Net;
using System.Threading;

namespace ListExample.Utility
{
    internal class HTTPClient
    {
        internal IWebProxy proxy;
        internal int timeout_ms;

        private class RequestInfo
        {
            public string uri, payload;
            public Action<string, Exception> callback;
            public Action<Stream, Exception> streamCallback;

            public RequestInfo(string uri, string payload, Action<string, Exception> callback, Action<Stream, Exception> streamCallback = null)
            {
                this.uri = uri;
                this.payload = payload;
                this.callback = callback;
                this.streamCallback = streamCallback;
            }
        }

        internal HTTPClient()
        {
            //do not autodetect proxy - it takes ages!
            proxy = WebRequest.GetSystemWebProxy();
            timeout_ms = 120000;
            ServicePointManager.DefaultConnectionLimit = 20;
        }

        private class WebClientWithCookies : System.Net.WebClient
        {
            private readonly CookieContainer _container;

            public WebClientWithCookies(CookieContainer container)
            {
                _container = container;
            }

            protected override WebRequest GetWebRequest(Uri address)
            {
                HttpWebRequest request = base.GetWebRequest(address) as HttpWebRequest;

                if (request != null)
                {
                    request.CookieContainer = _container;
                }

                return request;
            }
        }

        public void HttpGetJson<T>(string uri, Action<T, Exception> callback)
        {
            RequestInfo info = new RequestInfo(uri, null, (resp, err) =>
            {
                T response = default(T);
                if (resp != null)
                {
                    response = JsonMapper.ToObject<T>(resp);
                }
                callback(response, err);
            });

            ThreadPool.QueueUserWorkItem(_HttpGetJson, info);
        }

        /// <summary>
        /// Sends a GET request for json data to the specified URI and deserialises the response string into an object of type T.
        /// If this HTTPClient instance has a cookie, it is added to the GET request header.
        /// </summary>
        private void _HttpGetJson(Object data)
        {
            RequestInfo info = (RequestInfo)data;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(info.uri);
                request.Proxy = proxy;
                request.Method = "GET";
                request.Accept = "application/json";
                request.ReadWriteTimeout = timeout_ms;
                request.Timeout = timeout_ms;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                StreamReader responseReader = new StreamReader(responseStream);
                string responseData = responseReader.ReadToEnd();
                info.callback(responseData, null);
            }
            catch (WebException e)
            {
                // 3drepo.io does not return authentication failure, but instead a 500 internal server error, so recast this as a repowebclient exception
                if (e.Response is HttpWebResponse)
                {
                    HttpWebResponse hwr = (HttpWebResponse)e.Response;
                    info.callback(null, new Exception(GetResponseErrorAsString(hwr)));
                }
                else
                {
                    info.callback(null, new Exception(e.Message));
                }
            }
        }

        [Serializable]
        private class RepoError
        {
            public string message;
            public string code;
            public int value;
            public int status;
        };

        private string GetResponseErrorAsString(HttpWebResponse hwr)
        {
            Stream responseStream = hwr.GetResponseStream();
            StreamReader responseReader = new StreamReader(responseStream);
            return JsonMapper.ToObject<RepoError>(responseReader.ReadToEnd()).message;
        }

        private void _HttpGetStream(Object data)
        {
            RequestInfo info = (RequestInfo)data;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(info.uri);
                request.Proxy = proxy;
                request.Method = "GET";
                request.ReadWriteTimeout = timeout_ms;
                request.Timeout = timeout_ms;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                info.streamCallback(responseStream, null);
            }
            catch (WebException e)
            {
                // 3drepo.io does not return authentication failure, but instead a 500 internal server error, so recast this as a repowebclient exception
                if (e.Response is HttpWebResponse)
                {
                    HttpWebResponse hwr = (HttpWebResponse)e.Response;
                    info.streamCallback(null, new Exception(GetResponseErrorAsString(hwr)));
                }
                else
                {
                    info.streamCallback(null, new Exception(e.Message));
                }
            }
        }

        private void _HttpGetJsonGeneric(Object data)
        {
            RequestInfo info = (RequestInfo)data;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(info.uri);
                request.Proxy = proxy;
                request.Method = "GET";
                request.Accept = "application/json";
                request.ReadWriteTimeout = timeout_ms;
                request.Timeout = timeout_ms;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                StreamReader responseReader = new StreamReader(responseStream);
                string responseData = responseReader.ReadToEnd();

                info.callback(responseData, null);
            }
            catch (WebException e)
            {
                // 3drepo.io does not return authentication failure, but instead a 500 internal server error, so recast this as a repowebclient exception
                if (e.Response is HttpWebResponse)
                {
                    HttpWebResponse hwr = (HttpWebResponse)e.Response;
                    info.callback(null, new Exception(GetResponseErrorAsString(hwr)));
                }
                else
                {
                    info.callback(null, new Exception(e.Message));
                }
            }
        }

        public void HttpGetJsonGeneric(string uri, Action<JsonData, Exception> callback)
        {
            RequestInfo info = new RequestInfo(uri, null, (resp, err) =>
            {
                JsonData response = null;
                if (resp != null)
                {
                    response = JsonMapper.ToObject(resp);
                }

                callback(response, err);
            });

            ThreadPool.QueueUserWorkItem(_HttpGetJsonGeneric, info);
        }

        public void HttpGetRaw(string uri, Action<string, Exception> callback)
        {
            RequestInfo info = new RequestInfo(uri, null, (resp, err) =>
            {
                callback(resp, err);
            });

            ThreadPool.QueueUserWorkItem(_HttpGetJsonGeneric, info);
        }

        public void HttpGetStream(string uri, Action<Stream, Exception> callback)
        {
            RequestInfo info = new RequestInfo(uri, null, null, (resp, err) =>
            {
                callback(resp, err);
            });

            ThreadPool.QueueUserWorkItem(_HttpGetStream, info);
        }

        /// <summary>
        /// Sends a GET request to the specified URI and returns a Stream of bytes.
        /// If this HTTPClient instance has a cookie, it is added to the GET request header.
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public virtual Stream HttpGetURI(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Proxy = proxy;
            request.Method = "GET";
            request.ReadWriteTimeout = timeout_ms;
            request.Timeout = timeout_ms;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            return response.GetResponseStream();
        }
    }
}