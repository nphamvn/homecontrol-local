using System.Threading.Tasks;
using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using HomeControl.Devices.SDK.Controllers;

namespace GpioDevicesService.Services
{
    public class EnvironmentSensorService : EnvironmentSensor.EnvironmentSensorBase
    {
        private readonly EnvironmentSensorController _controller;
        private readonly IMapper _mapper;

        public EnvironmentSensorService(EnvironmentSensorController controller, IMapper mapper)
        {
            _controller = controller;
            _mapper = mapper;
        }
        public override async Task<EnvironmentSensorReply> GetSensorData(Empty request, ServerCallContext context)
        {
            var result = _controller.ReadSensorData();
            return _mapper.Map<EnvironmentSensorReply>(result);
        }
        // public override async Task<EnvironmentSensorReply> GetSensorData(Empty request, ServerCallContext context)
        // {
        //     // var result = _controller.ReadSensorData();
        //     // return Map(result);
        // }
    }
}