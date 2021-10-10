using System.Threading.Tasks;
using GpioDevicesService.Services.Interfaces;

namespace GpioDevicesService.Services
{
    public class InMemoryCache : ICacheService
    {
        public Task<T> Get<T>(string key)
        {
            throw new System.NotImplementedException();
        }

        public Task Set<T>(string key, T value)
        {
            throw new System.NotImplementedException();
        }
    }
}