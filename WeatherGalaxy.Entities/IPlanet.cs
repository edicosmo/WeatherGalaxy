using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherGalaxy.DTO;

namespace WeatherGalaxy.Entities
{
    public interface IPlanet
    {
        WeatherDto GetWeather(int day);
    }
}
