using System.Collections.Generic;
using WeatherGalaxy.Utils;

namespace WeatherGalaxy.Entities
{
    public class Galaxy
    {
        public List<Planet> Planets { get; set; }

        public Sun Sun { get; set; }

        public void SetPositionToPlanets(int day)
        {
            foreach (var planet in Planets)
            {
                planet.SetPosition(day);
            }
        }

        public double GetPerimeter()
        {
            var perimeter = MathUtils.GetPerimeter(Planets[0].GetXY(), Planets[1].GetXY(), Planets[2].GetXY());

            return perimeter;
        }
    }
}
