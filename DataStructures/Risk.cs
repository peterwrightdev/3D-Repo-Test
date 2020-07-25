using System;
using System.Collections.Generic;

namespace ListExample.DataStructures
{
    [Serializable]
    public class Risk
    {
        public string _id { get; set; } = null;
        public string owner { get; set; } = null;
        public Int64 created { get; set; } = 0;
        public string thumbnail { get; set; } = null;
        public string name { get; set; } = "";
        public string desc { get; set; } = "";
        public string mitigation_status = "";
        public Int32 overall_level_of_risk = -1;
        public string category = "";
    }

    [Serializable]
    public class RiskList
    {
        public List<Risk> risks = null;
    }
}