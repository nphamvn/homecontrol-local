using System;
using System.Threading.Tasks;
using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using GpioDevicesService.Models;
using GpioDevicesService.Services.Interfaces;
using Grpc.Core;
using HomeControl.Devices.SDK.Controllers;

namespace GpioDevicesService.Services
{
    public class LightService : Light.LightBase
    {
        private const string CACHE_KEY = "light";

        private readonly LightRemoteController _remoteController;
        private readonly ICacheService _cache;
        private readonly IMapper _mapper;

        public LightService(LightRemoteController controller,
        ICacheService cache,
        IMapper mapper)
        {
            _remoteController = controller;
            _cache = cache;
            _mapper = mapper;
        }
        public override async Task<LightReply> GetState(Empty request, ServerCallContext context)
        {
            var currentState = await _cache.Get<LightRecord>("light");
            return _mapper.Map<LightReply>(currentState);
        }

        public override async Task<LightReply> TurnOnLight(Empty request, ServerCallContext context)
        {
            var currentState = await _cache.Get<LightRecord>("light");
            switch (currentState.Mode)
            {
                case "ON":
                    break;
                case "OFF":
                    //TODO: Edit
                    await _remoteController.PushPowerButton();
                    break;
                default:
                    break;
            }
            var newState = currentState with { Mode = "ON" };
            await SaveState(newState);
            return _mapper.Map<LightReply>(newState);
        }

        public override async Task<LightReply> TurnOffLight(Empty request, ServerCallContext context)
        {
            var currentState = await _cache.Get<LightRecord>("light");
            switch (currentState.Mode)
            {
                case "ON":
                    await _remoteController.PushPowerButton();
                    await Task.Delay(100);
                    await _remoteController.PushPowerButton();
                    break;
                case "OFF":
                    break;
                default:
                    break;
            }
            var newState = currentState with { Mode = "ON" };
            await SaveState(newState);
            return _mapper.Map<LightReply>(newState);
        }

        public override async Task<LightReply> BrightenLight(Empty request, ServerCallContext context)
        {
            var currentState = await _cache.Get<LightRecord>("light");
            var newState = currentState;
            switch (currentState.Mode)
            {
                case "ON":
                    await _remoteController.PushBrightenLightButton();
                    newState = newState with { Brightness = currentState.Brightness + 1 };
                    break;
                case "OFF":
                    break;
                default:
                    break;
            }
            await SaveState(newState);
            return _mapper.Map<LightReply>(newState);
        }

        public override async Task<LightReply> DimLight(Empty request, ServerCallContext context)
        {
            var currentState = await _cache.Get<LightRecord>("light");
            var newState = currentState;
            switch (currentState.Mode)
            {
                case "ON":
                    await _remoteController.PushDimLightButtons();
                    newState = newState with { Brightness = currentState.Brightness + 1 };
                    break;
                case "OFF":
                    break;
                default:
                    break;
            }
            await SaveState(newState);
            return _mapper.Map<LightReply>(newState);
        }

        private async Task SaveState(LightRecord state)
        {
            await _cache.Set("light", state);
        }
    }
}