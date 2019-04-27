using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherGalaxy.Models;

namespace WeatherGalaxy.Infrastructure
{
    public static class MathUtils
    {
        public static bool IsPointsAligned(double[] p1, double[] p2, double[] p3)
        {
            var value1 = ((p2[0] - p1[0]) / (p3[0] - p2[0]));
            var value2 = ((p2[1] - p1[1]) / (p3[1] - p2[1]));

            return value1 == value2;
        }

        private static double GetSlope(Planet planet)
        {
            return planet.GetY() / planet.GetX();
        }

        public static bool AlignedWithSun(double[] p1, double[] p2, double[] p3)
        {
            return IsPointsAligned(Sun.GetXY(), p1, p2) && IsPointsAligned(Sun.GetXY(), p2, p3);
        }

        public static double TriangleOrientation(double[] p1, double[] p2, double[] p3)
        {
            // If orientation >= 0  => positive
            // If orientation <= 0  => negative

            // Triangle ABC => Orientation: (A.x - C.x) * (B.y - C.y) - (A.y - C.y) * (B.x - C.x)

            return ((p1[0] - p3[0]) * (p2[1] - p3[1])) - ((p1[1] - p3[1]) * (p2[0] - p3[0]));
        }


    }
}