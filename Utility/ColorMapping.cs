using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListExample.Utility
{
    public static class ColorMapping
    {
        public static Dictionary<object, string> Mapping = new Dictionary<object, string>()
        {
            { "low", "#f6e985" },
            { "medium", "#f7bb83" },
            { "high", "#c27676" },
            { "closed", "#7ca687" },
            { "default", "#4e7496"},
            { 0,  "#7ca687"},
            { 1,  "#96c858"},
            { 2,  "#f6e985"},
            { 3,  "#f7bb83"},
            { 4,  "#c27676"},
        };
    }
}
