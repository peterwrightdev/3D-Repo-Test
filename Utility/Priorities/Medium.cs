using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ListExample.Utility.Priorities
{
    public class Medium : IPriority
    {
        public Color Colour { get { return (Color)ColorConverter.ConvertFromString("#f7bb83"); } }
    }
}
