using System;
using IotHome.RaspberryPi.Model;

namespace IotHome.RaspberryPi.Console.Configuration
{
    public class AppSettings
    {
        public string ConnectionString { get; set; }

        public int ProcessingIntervalInSeconds { get; set; }

        public int IotHubSendIntervalInSeconds { get; set; }

        public TimeSpan ProcessingInterval => TimeSpan.FromSeconds(ProcessingIntervalInSeconds);

        public TimeSpan IotHubSendInterval => TimeSpan.FromSeconds(IotHubSendIntervalInSeconds);

        public SensorSettings[] SensorSettings { get; set; }
    }
}
