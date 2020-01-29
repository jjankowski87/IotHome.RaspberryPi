using IotHome.RaspberryPi.Model;

namespace IotHome.RaspberryPi.Interface.Sensor
{
    public interface ISensor
    {
        ReadingType ReadingType { get; }

        string Name { get; }

        decimal ReadValue();
    }
}
