using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parabola.Server.Data
{
    public class UserData
    {
        public int UserDataId { get; set; }
        public int RangeFrom { get; set; }
        public int RangeTo { get; set; }
        public int step { get; set; }
        public int a { get; set; }
        public int b { get; set; }
        public int c { get; set; }

        public int ChartId { get; set; }
        IEnumerable<Point> Points { get; set; }
    }
}