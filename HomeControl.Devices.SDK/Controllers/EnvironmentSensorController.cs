using System.Device.I2c;
using HomeControl.Devices.SDK.Models;
using HomeControl.Devices.SDK.Settings;
using Iot.Device.Bmxx80;
using Iot.Device.Bmxx80.ReadResult;
using Microsoft.Extensions.Options;

namespace HomeControl.Devices.SDK.Controllers
{
    public class EnvironmentSensorController
    {
        private readonly Bme280 bme280;
        public EnvironmentSensorController(IOptions<EnvironmentSensorOptions> options)
        {
            //var i2cSettings = new I2cConnectionSettings(1, Bme280.DefaultI2cAddress);
            var setting = options.Value;
            var i2cSettings = new I2cConnectionSettings(setting.I2cConnectionBusID, setting.I2cConnectionDeviceAddress);
            I2cDevice i2cDevice = I2cDevice.Create(i2cSettings);
            bme280 = new Bme280(i2cDevice);
        }
        public EnvironmentSensorData ReadSensorData()
        {
            Bme280ReadResult output = bme280.Read();
            double temperature = output.Temperature.Value.DegreesCelsius;
            double humidity = output.Humidity.Value.Percent;
            return new EnvironmentSensorData
            {
                Temperature = temperature,
                Humidity = humidity,
                ReadingTime = System.DateTime.Now
            };
        }
    }
}