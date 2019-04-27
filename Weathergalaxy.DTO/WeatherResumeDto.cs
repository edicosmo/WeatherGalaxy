using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherGalaxy.DTO
{
    public class WeatherResumeDto
    {
        public int DroughtDays { get; set; }

        public int RainDays { get; set; }

        public int OptimalDays { get; set; }

        public int RainPeakDay { get; set; }

        public double MaxPerimeter { get; set; }

        public int UnknownDays { get; set; }
    }
}
