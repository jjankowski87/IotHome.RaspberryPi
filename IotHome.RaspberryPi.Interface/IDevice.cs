using System.Threading.Tasks;
using IotHome.RaspberryPi.Interface.Sensor;

namespace IotHome.RaspberryPi.Interface
{
    public interface IDevice
    {
        Task ProcessSensorAsync(ISensor sensor);
    }
}
