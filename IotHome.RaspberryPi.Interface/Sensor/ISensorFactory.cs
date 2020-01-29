using IotHome.RaspberryPi.Model;

namespace IotHome.RaspberryPi.Interface.Sensor
{
    public interface ISensorFactory
    {
        ISensor CreateSensor(SensorSettings sensorSettings);
    }
}