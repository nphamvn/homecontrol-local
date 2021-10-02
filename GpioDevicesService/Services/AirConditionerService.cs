using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public AirConditionerService(AirConRemoteController remoteController,
        ICacheService cacheService,
        IMapper mapper)
        {
            _remoteController = remoteController;
            _cacheService = cacheService;
            _mapper = mapper;
        }
        public override async Task<AirConditionerReply> GetState(Empty request, ServerCallContext context)
        {
            var currentState = await _cacheService.Get<AirConditionerRecord>();
            return _mapper.Map<AirConditionerReply>(currentState);
        }

        public override async Task<AirConditionerReply> TurnOnCooler(Empty request, ServerCallContext context)
        {
            var currentState = await _cacheService.Get<AirConditionerRecord>();
            await _remoteController.PushCoolerButton();
            var newState = currentState with { Mode = "COOLER" };
            await _cacheService.Set(newState);
            return _mapper.Map<AirConditionerReply>(newState);
        }
        public override async Task<AirConditionerReply> TurnOnHeater(Empty request, ServerCallContext context)
        {
            var currentState = await _cacheService.Get<AirConditionerRecord>();
            await _remoteController.PushHeaterButton();
            var newState = currentState with { Mode = "HEATER" };
            await _cacheService.Set(newState);
            return _mapper.Map<AirConditionerReply>(newState);
        }
        public override async Task<AirConditionerReply> IncreaseTemperature(Empty request, ServerCallContext context)
        {
            var currentState = await _cacheService.Get<AirConditionerRecord>();
            await _remoteController.PushIncTempButton();
            int temperature = currentState.Temperature + 1;
            var newState = currentState with { Temperature = temperature };
            await _cacheService.Set(newState);
            return _mapper.Map<AirConditionerReply>(newState);
        }
        public override async Task<AirConditionerReply> DecreaseTemperature(Empty request, ServerCallContext context)
        {
            var currentState = await _cacheService.Get<AirConditionerRecord>();
            await _remoteController.PushIncTempButton();
            int temperature = currentState.Temperature - 1;
            var newState = currentState with { Temperature = temperature };
            await _cacheService.Set(newState);
            return _mapper.Map<AirConditionerReply>(newState);
        }
    }
}