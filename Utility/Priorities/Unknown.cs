using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ListExample.Utility.Priorities
{
    public class Unknown : IPriority
    {
        public Color Colour { get { return (Color)ColorConverter.ConvertFromString("#4e7496"); } }
    }
}
