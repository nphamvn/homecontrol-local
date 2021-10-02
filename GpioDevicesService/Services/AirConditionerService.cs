using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using GpioDevicesService.Models;
using GpioDevicesService.Services.Interfaces;
using Grpc.Core;
using HomeControl.Devices.SDK.Controllers;

namespace GpioDevicesService.Services
{
    public class AirConditionerService : AirConditioner.AirConditionerBase
    {
        private readonly AirConRemoteController _remoteController;
        private readonly ICacheService _cacheService;

        public AirConditionerService(AirConRemoteController remoteController, ICacheService cacheService)
        {
            _remoteController = remoteController;
            _cacheService = cacheService;
        }
        public override async Task<AirConditionerReply> TurnOnCooler(Empty request, ServerCallContext context)
        {
            //return base.TurnOnCooler(request, context);
            var currentState = await _cacheService.Get<AirConditionerRecord>();
            await _remoteController.PushCoolerButton();
            var newState = currentState with { Mode = "COOLER" };
            return new AirConditionerReply
            {
                Mode = newState.Mode,
                Temperature = newState.Temperature
            };
        }
        public override async Task<AirConditionerReply> TurnOnHeater(Empty request, ServerCallContext context)
        {
            var currentState = await _cacheService.Get<AirConditionerRecord>();
            await _remoteController.PushHeaterButton();
            var newState = currentState with { Mode = "HEATER" };
            return new AirConditionerReply
            {
                Mode = newState.Mode,
                Temperature = newState.Temperature
            };
        }
        public override async Task<AirConditionerReply> IncreaseTemperature(Empty request, ServerCallContext context)
        {
            var currentState = await _cacheService.Get<AirConditionerRecord>();
            await _remoteController.PushIncTempButton();
            int temperature = currentState.Temperature + 1;
            var newState = currentState with { Temperature = temperature };
            return new AirConditionerReply
            {
                Mode = newState.Mode,
                Temperature = newState.Temperature
            };
        }
        public override async Task<AirConditionerReply> DecreaseTemperature(Empty request, ServerCallContext context)
        {
            var currentState = await _cacheService.Get<AirConditionerRecord>();
            await _remoteController.PushIncTempButton();
            int temperature = currentState.Temperature - 1;
            var newState = currentState with { Temperature = temperature };
            return new AirConditionerReply
            {
                Mode = newState.Mode,
                Temperature = newState.Temperature
            };
        }
    }
}