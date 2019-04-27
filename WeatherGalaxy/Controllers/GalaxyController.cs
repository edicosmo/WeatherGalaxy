using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WeatherGalaxy.DTO;
using WeatherGalaxy.Entities;
using WeatherGalaxy.Factory;

namespace WeatherGalaxy.Utils
{
    public class GalaxyController: ApiController
    {
        // GET api/clima/5

        /// <summary>
        ///  Return a list of strings.
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<string> Clima(int day)
        {
            return new string[] { "value1", "value2" };
        }

        //GET api/GetWeatherResume

        /// <summary>
        /// Return a resume of Weather
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public WeatherResumeDto GetWeatherResume()
        {
            var weatherResume = CreateWeatherResume();

            var galaxy = new Galaxy();

            galaxy.Planets.Add(PlanetFactory.GetPlanetVulcano());
            galaxy.Planets.Add(PlanetFactory.GetPlanetBetasoide());
            galaxy.Planets.Add(PlanetFactory.GetPlanetFerengi());
            galaxy.Sun = new Sun();

            // 1 year = 360 days

            for (int day = 1; day < 3600; day++)
            {
                galaxy.SetPositionToPlanets(day);

                if (WeatherUtils.IsDrought(galaxy))
                {
                    weatherResume.DroughtDays++;
                }
                else if (WeatherUtils.IsRaining(galaxy))
                {
                    var galaxyPerimeter = galaxy.GetPerimeter();

                    weatherResume.RainDays++;

                    if (weatherResume.MaxPerimeter < galaxyPerimeter)
                    {
                        weatherResume.RainPeakDay = day;
                        weatherResume.MaxPerimeter = galaxyPerimeter;
                    }
                }
                else if (WeatherUtils.IsOptimal(galaxy))
                {
                    weatherResume.OptimalDays++;
                }
                else
                {
                    weatherResume.UnknownDays++;
                }
            }

            return weatherResume;
        }

        private WeatherResumeDto CreateWeatherResume()
        {
            var weatherResume = new WeatherResumeDto();

            weatherResume.DroughtDays = 0;
            weatherResume.OptimalDays = 0;
            weatherResume.RainDays = 0;
            weatherResume.UnknownDays = 0;

            return weatherResume;
        }
    }
}