using System;
using IotHome.RaspberryPi.Interface.Sensor;
using IotHome.RaspberryPi.Model;

namespace IotHome.RaspberryPi.Implementation.Sensor
{
    public class RandomSensor : ISensor
    {
        private static readonly Random Random = new Random(DateTime.Now.Millisecond);
        private readonly decimal _value;
        private readonly decimal _deviation;

        public RandomSensor(decimal value, decimal deviation, string name, ReadingType readingType)
        {
            _value = value;
            _deviation = deviation;
            Name = name;
            ReadingType = readingType;
        }

        public ReadingType ReadingType { get; }

        public string Name { get; }

        public decimal ReadValue()
        {
            return Math.Round(_value + _deviation - (decimal)Random.NextDouble() * 2m * _deviation, 2);
        }
    }
}
