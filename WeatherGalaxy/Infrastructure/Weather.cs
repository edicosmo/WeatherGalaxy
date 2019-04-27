using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherGalaxy.Models;


namespace WeatherGalaxy.Infrastructure
{
    public static class Weather
    {
        public static bool IsDrought(Planet p1, Planet p2, Planet p3)
        {
            return MathUtils.AlignedWithSun(p1.GetXY(), p2.GetXY(), p3.GetXY());
        }

        public static bool IsRaining(Planet p1, Planet p2, Planet p3)
        {
            var pointsP1 = p1.GetXY();
            var pointsP2 = p2.GetXY();
            var pointsP3 = p3.GetXY();
            var pointsSun = Sun.GetXY();

            if (!MathUtils.IsPointsAligned(pointsP1, pointsP2, pointsP3))
            {
                var OriginalTriangleOrientation = MathUtils.TriangleOrientation(pointsP1, pointsP2, pointsP3);

                var p1P2SunOrientation = MathUtils.TriangleOrientation(pointsP1, pointsP2, pointsSun);
                var p2P3SunOrientation = MathUtils.TriangleOrientation(pointsP2, pointsP3, pointsSun);
                var p3P1SunOrientation = MathUtils.TriangleOrientation(pointsP3, pointsP1, pointsSun);

                return (OriginalTriangleOrientation == p1P2SunOrientation) && (OriginalTriangleOrientation == p2P3SunOrientation) && (OriginalTriangleOrientation == p3P1SunOrientation);
            }

            return false;
        }


    }
}