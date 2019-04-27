using WeatherGalaxy.Entities;
using WeatherGalaxy.Enums;

namespace WeatherGalaxy.Factory
{
    public static class PlanetFactory
    {
        public static Planet GetPlanetBetasoide()
        {
            return new Planet("Betasoide", 3, RotationEnum.clockwise, 2000, 1);
        }

        public static Planet GetPlanetFerengi()
        {
            return new Planet("Ferengi", 1, RotationEnum.clockwise, 500, 1);
        }

        public static Planet GetPlanetVulcano()
        {
            return new Planet("Vulcano", 5, RotationEnum.anticlockwise, 1000, 1);
        }
    }
}
