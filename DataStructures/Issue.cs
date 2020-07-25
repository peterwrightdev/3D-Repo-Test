using System;
using System.Collections.Generic;

namespace ListExample.DataStructures
{
    [Serializable]
    public class IssuesList
    {
        public List<Issue> issues = null;
    }

    [Serializable]
    public class Issue
    {
        public string _id { get; set; } = "";
        public string name { get; set; } = "";
        public string status = "";
        public string owner { get; set; } = "";
        public Int64 created { get; set; } = 0;
        public Int64 due_date { get; set; } = 0;
        public int number { get; set; } = -1;
        public string topic_type { get; set; } = "";
        public string priority { get; set; } = "";
        public string desc { get; set; } = "";
        public string thumbnail { get; set; }
    }
}