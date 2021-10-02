using System;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using GpioDevicesService.Models;
using GpioDevicesService.Services.Interfaces;
using Grpc.Core;
using HomeControl.Devices.SDK.Controllers;

namespace GpioDevicesService.Services
{
    public class LightService : Light.LightBase
    {
        private readonly LightRemoteController _controller;
        private readonly ICacheService _cache;

        public LightService(LightRemoteController controller, ICacheService cache)
        {
            _controller = controller;
            _cache = cache;
        }
        public override async Task<LightReply> GetStatus(Empty request, ServerCallContext context)
        {
            //Read from cache service or file
            //return base.GetStatus(request, context);
            var current = await _cache.Get<LightRecord>();
            return new LightReply
            {
                Brightness = current.Brightness,
                Mode = current.Mode
            };
        }

        public override async Task<LightReply> TurnOnLight(Empty request, ServerCallContext context)
        {
            //Read current state from cache
            var current = await _cache.Get<LightRecord>();

            //TODO: do logic then push button
            if (current.Mode == "OFF")
            {
                await _controller.PushPowerButton();
            }

            //return base.TurnOnLight(request, context);
            var newState = current with { Mode = "ON" };

            //Save new state to cache
            await _cache.Set(newState);

            return new LightReply
            {
                Mode = newState.Mode,
                Brightness = newState.Brightness
            };
        }

        public override async Task<LightReply> TurnOffLight(Empty request, ServerCallContext context)
        {
            //Read current state from cache
            var current = await _cache.Get<LightRecord>();

            //TODO: do logic then push button
            if (current.Mode == "ON")
            {
                await _controller.PushPowerButton();
            }

            //return base.TurnOnLight(request, context);
            var newState = current with { Mode = "OFF" };

            //Save new state to cache
            await _cache.Set(newState);

            return new LightReply
            {
                Mode = newState.Mode,
                Brightness = newState.Brightness
            };
        }

        public override Task<LightReply> BrightenLight(Empty request, ServerCallContext context)
        {
            //Save change
            return base.BrightenLight(request, context);
        }

        public override Task<LightReply> DimLight(Empty request, ServerCallContext context)
        {
            //Save change
            return base.DimLight(request, context);
        }

        private static LightReply Map()
        {
            return new LightReply
            {

            };
        }
    }
}