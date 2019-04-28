using WeatherGalaxy.Utils;

namespace WeatherGalaxy.Entities
{
    public static class WeatherCondition
    {
        public static bool IsDrought(Galaxy galaxy)
        {
            return MathUtils.AlignedWithSun(galaxy.Planets[0].GetXY(), galaxy.Planets[1].GetXY(), galaxy.Planets[0].GetXY(), galaxy.Sun.GetXY());
        }

        public static bool IsRaining(Galaxy galaxy)
        {
            var pointsP1 = galaxy.Planets[0].GetXY();
            var pointsP2 = galaxy.Planets[1].GetXY();
            var pointsP3 = galaxy.Planets[2].GetXY();
            var pointsSun = galaxy.Sun.GetXY();

            if (MathUtils.IsTriangle(pointsP1, pointsP2, pointsP3))
            {
                var originalTriangleOrientation = MathUtils.TriangleOrientation(pointsP1, pointsP2, pointsP3);

                var pl1Pl2SunOrientation = MathUtils.TriangleOrientation(pointsP1, pointsP2, pointsSun);
                var pl2Pl3SunOrientation = MathUtils.TriangleOrientation(pointsP2, pointsP3, pointsSun);
                var pl3Pl1SunOrientation = MathUtils.TriangleOrientation(pointsP3, pointsP1, pointsSun);

                return (originalTriangleOrientation == pl1Pl2SunOrientation) && (originalTriangleOrientation == pl2Pl3SunOrientation) && (originalTriangleOrientation == pl3Pl1SunOrientation);
            }

            return false;
        }

        public static bool IsOptimal(Galaxy galaxy)
        {
            var pointsP1 = galaxy.Planets[0].GetXY();
            var pointsP2 = galaxy.Planets[1].GetXY();
            var pointsP3 = galaxy.Planets[2].GetXY();

            return !IsDrought(galaxy) && MathUtils.IsPointsAligned(pointsP1,pointsP2,pointsP3);
        }
    }
}