using ListExample.DataStructures;
using LitJson;
using System;
using System.Collections.Generic;
using System.IO;

namespace ListExample.Utility
{
    internal class DataManager
    {
        private HTTPClient client = new HTTPClient();
        private readonly string apiDomain = "https://api1.www.3drepo.io/api";
        private readonly string teamspace = "carmen";
        private readonly string model = "1253c590-c29f-11ea-b809-15db7aeb54e1";

        private readonly string apiKey = "1f036cd6fd45487570ec908114c46e38";

        internal void GetIssueList(Action<List<Issue>, Exception> callback)
        {
            string issueListURI = string.Format(@"{0}/{1}/{2}/issues?key={3}", apiDomain, teamspace, model, apiKey);
            client.HttpGetRaw(issueListURI, (rawData, ex) =>
            {
                List<Issue> res = null;
                if (ex == null)
                {
                    string data = "{\"issues\":" + rawData + "}";
                    var issueList = JsonMapper.ToObject<IssuesList>(data);
                    res = issueList.issues;
                }
                callback(res, ex);
            });
        }

        internal void GetRiskList(Action<List<Risk>, Exception> callback)
        {
            string riskListURI = string.Format(@"{0}/{1}/{2}/risks?key={3}", apiDomain, teamspace, model, apiKey);
            client.HttpGetRaw(riskListURI, (rawData, ex) =>
            {
                List<Risk> res = null;
                if (ex == null)
                {
                    string data = "{\"risks\":" + rawData + "}";
                    var list = JsonMapper.ToObject<RiskList>(data);
                    res = list.risks;
                }
                callback(res, ex);
            });
        }

        internal void GetBinaryStream(string uri, Action<Stream, Exception> callback)
        {
            string fullURL = string.Format(@"{0}/{1}?key={2}", apiDomain, uri, apiKey);
            client.HttpGetStream(fullURL, callback);
        }
    }
}