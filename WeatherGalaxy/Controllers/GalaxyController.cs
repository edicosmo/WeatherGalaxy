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
    /// <summary>
    /// 
    /// </summary>
    public class GalaxyController : ApiController
    {
        //GET api/Galaxy/GetWeatherResume

        /// <summary>
        ///  Return a summary.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public WeatherResumeDto GetWeatherResume()
        {
            var weatherResume = CreateWeatherResume();

            var galaxy = CreateGalaxy();

            // 1 year = 360 days

            for (int day = 1; day <= 3600; day++)
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

        /// <summary>
        /// Based on a specific day, return the weather for that day.
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        [HttpGet]
        public WeatherDto Clima(int day)
        {
            var galaxy = CreateGalaxy();
            var weather = new WeatherDto(day);

            galaxy.SetPositionToPlanets(day);

            if (WeatherUtils.IsDrought(galaxy))
            {
                weather.Weather = "Sequia";
            }
            else if (WeatherUtils.IsRaining(galaxy))
            {
                weather.Weather = "Lluvia";
            }
            else if (WeatherUtils.IsOptimal(galaxy))
            {
                weather.Weather = "Optimo";
            }
            else
            {
                weather.Weather = "Desconocido";
            }

            return weather;
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

        private Galaxy CreateGalaxy()
        {
            var galaxy = new Galaxy();

            galaxy.Planets.Add(PlanetFactory.GetPlanetVulcano());
            galaxy.Planets.Add(PlanetFactory.GetPlanetBetasoide());
            galaxy.Planets.Add(PlanetFactory.GetPlanetFerengi());
            galaxy.Sun = new Sun();

            return galaxy;
        }
    }
}