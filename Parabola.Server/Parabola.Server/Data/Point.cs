using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parabola.Server.Data
{
    public class Point
    {
        public int PointId { get; set; }
        public int ChartId { get; set; }
        public double PointX { get; set; }
        public double PointY { get; set; }

        public UserData UserData { get; set; }
    }
}