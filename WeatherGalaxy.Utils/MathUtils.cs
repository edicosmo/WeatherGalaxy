using System;
using WeatherGalaxy.Entities;

namespace WeatherGalaxy.Utils
{
    public static class MathUtils
    {
        public static bool IsPointsAligned(double[] p1, double[] p2, double[] p3)
        {
            var value1 = ((p2[0] - p1[0]) / (p3[0] - p2[0]));
            var value2 = ((p2[1] - p1[1]) / (p3[1] - p2[1]));

            return value1 == value2;
        }

        public static bool AlignedWithSun(double[] p1, double[] p2, double[] p3, Sun sun)
        {
            return IsPointsAligned(sun.GetXY(), p1, p2) && IsPointsAligned(sun.GetXY(), p2, p3);
        }

        public static bool TriangleOrientation(double[] p1, double[] p2, double[] p3)
        {
            // If orientation >= 0  => positive
            // If orientation <= 0  => negative

            // Triangle ABC => Orientation: (A.x - C.x) * (B.y - C.y) - (A.y - C.y) * (B.x - C.x)

            if ((((p1[0] - p3[0]) * (p2[1] - p3[1])) - ((p1[1] - p3[1]) * (p2[0] - p3[0]))) >= 0)
            {
                return true;
            }
            else
                return false;
        }

        public static bool IsTriangle(double[] p1, double[] p2, double[] p3)
        {
            return !IsPointsAligned(p1, p2, p3);
        }

        public static double GetPerimeter(double[] p1, double[] p2, double[] p3)
        {
            var dist12 = Math.Sqrt(Math.Pow(p1[0] + p2[0], 2) + Math.Pow(p1[1] + p2[1], 2));
            var dist23 = Math.Sqrt(Math.Pow(p2[0] + p3[0], 2) + Math.Pow(p2[1] + p3[1], 2));
            var dist31 = Math.Sqrt(Math.Pow(p3[0] + p1[0], 2) + Math.Pow(p3[1] + p1[1], 2));

            return dist12 + dist23 + dist31;
        }
    }
}