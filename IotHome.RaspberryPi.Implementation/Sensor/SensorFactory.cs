using System;
using IotHome.RaspberryPi.Interface;
using IotHome.RaspberryPi.Interface.Sensor;
using IotHome.RaspberryPi.Model;

namespace IotHome.RaspberryPi.Implementation.Sensor
{
    public class SensorFactory : ISensorFactory
    {
        private readonly IShellHelper _shellHelper;

        public SensorFactory(IShellHelper shellHelper)
        {
            _shellHelper = shellHelper;
        }

        public ISensor CreateSensor(SensorSettings sensorSettings)
        {
            switch (sensorSettings.Type)
            {
                case SensorType.RandomThermometer:
                    return new RandomThermometer();
                case SensorType.ChipsetThermometer:
                    return new ChipsetThermometer(_shellHelper, sensorSettings.Name);
                case SensorType.DS18B20:
                    return new DS18B20Thermometer(_shellHelper, sensorSettings);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}