using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using HomeControl.Devices.SDK.Controllers;

namespace GpioDevicesService.Services
{
    public class EnvironmentSensorService : EnvironmentSensor.EnvironmentSensorBase
    {
        private readonly EnvironmentSensorController _controller;

        public EnvironmentSensorService(EnvironmentSensorController controller)
        {
            _controller = controller;
        }

        public override async Task<SensorReply> GetSensorData(Empty request, ServerCallContext context)
        {
            var result = _controller.ReadSensorData();
            return Map(result);
        }

        private static SensorReply Map(HomeControl.Devices.SDK.Models.EnvironmentSensorData value)
        {
            return new SensorReply
            {
                Temperature = value.Temperature,
                Humindity = value.Humidity,
                Time = value.ReadingTime.ToString("yyyyMMdd HHmmss")
            };
        }
    }
}