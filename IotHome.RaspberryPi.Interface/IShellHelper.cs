using System.Threading.Tasks;

namespace IotHome.RaspberryPi.Interface
{
    public interface IShellHelper
    {
        Task<string> ExecuteCommandAsync(string command);
    }
}
