using System.Threading.Tasks;
using HomeControl.Devices.SDK.Settings;
using Microsoft.Extensions.Options;

namespace HomeControl.Devices.SDK.Controllers
{
    public class AirConRemoteController : RemoteController
    {
        private readonly AirConditionerOptions _settings;

        public AirConRemoteController(IOptions<AirConditionerOptions> options) :
        base(options.Value.RemoteName)
        {
            _settings = options.Value;
        }

        public async Task PushCoolerButton()
        {
            SendCode(_settings.RemoteName);
        }
        public async Task PushHeaterButton()
        {
            SendCode(_settings.HeaterButtonCode);
        }

        public async Task PushOffButton()
        {
            SendCode(_settings.OffButtonCode);
        }

        public async Task PushIncTempButton()
        {
            SendCode(_settings.IncTempButtonCode);
        }
        public async Task PushDecTempButton()
        {
            SendCode(_settings.DecTempButtonCode);
        }
    }
}