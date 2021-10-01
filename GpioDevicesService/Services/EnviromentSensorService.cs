using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace GpioDevicesService.Services
{
    public class EnvironmentSensorService : EnvironmentSensor.EnvironmentSensorBase
    {
        public EnvironmentSensorService()
        {

        }

        public override Task<SensorReply> GetSensorData(Empty request, ServerCallContext context)
        {
            return base.GetSensorData(request, context);
        }
    }
}