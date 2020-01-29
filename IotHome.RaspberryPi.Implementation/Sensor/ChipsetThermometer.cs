using System;
using System.Globalization;
using IotHome.RaspberryPi.Interface;
using IotHome.RaspberryPi.Interface.Sensor;
using IotHome.RaspberryPi.Model;

namespace IotHome.RaspberryPi.Implementation.Sensor
{
    public class ChipsetThermometer : ISensor
    {
        private readonly IShellHelper _shellHelper;

        public ChipsetThermometer(IShellHelper shellHelper, string name)
        {
            _shellHelper = shellHelper;
            Name = name;
        }

        public ReadingType ReadingType => ReadingType.Temperature;

        public string Name { get; }

        public decimal ReadValue()
        {
            // temp=47.8'C
            var stringTemp = _shellHelper.ExecuteCommandAsync("/opt/vc/bin/vcgencmd measure_temp").Result;
            stringTemp = stringTemp.Replace("temp=", string.Empty).Replace("'C", string.Empty);

            return Convert.ToDecimal(stringTemp, CultureInfo.GetCultureInfo("en-gb"));
        }
    }
}
