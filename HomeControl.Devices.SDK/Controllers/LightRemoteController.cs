using System.Threading.Tasks;
using HomeControl.Devices.SDK.Settings;
using Microsoft.Extensions.Options;

namespace HomeControl.Devices.SDK.Controllers
{
    public class LightRemoteController : RemoteController
    {
        private readonly LightOptions _settings;

        public LightRemoteController(IOptions<LightOptions> options) :
            base(options.Value.RemoteName)
        {
            _settings = options.Value;
        }

        public async Task PushPowerButton()
        {
            base.SendCode(_settings.PowerButtonCode);
        }

        public async Task PushBrightenLightButton()
        {
            base.SendCode(_settings.BrightenButtonCode);
        }

        public async Task PushDimLightButtons()
        {
            base.SendCode(_settings.DimButtonCode);
        }
    }
}