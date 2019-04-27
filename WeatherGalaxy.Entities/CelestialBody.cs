using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherGalaxy.Entities
{
    public abstract class CelestialBody
    {
        private string v1;
        private int v2;
        private int v3;

        public CelestialBody(string name, double positionX, double positionY)
            :this(name)
        {
            PositionX = positionX;
            PositionY = positionY;
        }

        public CelestialBody(string name)
        {
            Name = name;
        }

        protected string Name { get; set; }

        protected double PositionX { get; set; }

        protected double PositionY { get; set; }

        public double GetX()
        {
            return PositionX;
        }

        public double GetY()
        {
            return PositionY;
        }

        public double[] GetXY()
        {
            return new double[] { PositionX, PositionY };
        }
    }
}
