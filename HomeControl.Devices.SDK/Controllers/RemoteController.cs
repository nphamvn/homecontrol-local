using System.Diagnostics;
using System.Threading.Tasks;
using HomeControl.Devices.SDK.Settings;
using Microsoft.Extensions.Options;

namespace HomeControl.Devices.SDK.Controllers
{
    public class RemoteController
    {
        private string _remoteName;
        public string RemoteName
        {
            get { return _remoteName; }
            set { _remoteName = value; }
        }

        public RemoteController(string remoteName)
        {
            _remoteName = remoteName;
        }
        protected void SendCode(string code)
        {
            /* Build process info to call LIRC */
            ProcessStartInfo procInfo = new ProcessStartInfo();
            procInfo.FileName = "irsend";
            procInfo.UseShellExecute = false;
            procInfo.RedirectStandardOutput = true;

            /* Ask LIRC for a list of remotes */
            procInfo.Arguments = "SEND_ONCE " + this.RemoteName + " " + code;
            Process proc = Process.Start(procInfo);
        }
    }
}