using System;
using WeatherGalaxy.Enums;

namespace WeatherGalaxy.Entities
{
    public class Planet : CelestialBody
    {

        private int Speed { get; set; }

        private RotationEnum Rotation { get; set; }

        private int Radius { get; set; }

        public Planet(string name, int speed, RotationEnum rotation, int radius, int day)
            :base(name)
        {
            Speed = speed;
            Rotation = rotation;
            Radius = radius;
            SetPosition(day);
        }

        public void SetPosition(int day)
        {
            PositionX = Math.Cos(Speed * day * (int)Rotation);
            PositionY = Math.Sin(Speed * day * (int)Rotation);
        }

    }
}