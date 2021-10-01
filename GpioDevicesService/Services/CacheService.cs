using System.Threading.Tasks;
using GpioDevicesService.Services.Interfaces;
using Microsoft.Extensions.Caching.Distributed;

namespace GpioDevicesService.Services
{
    public class CacheService<T> : ICacheService<T>
    {
        private readonly IDistributedCache _distributedCache;

        public CacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        public Task<T> Get()
        {
            throw new System.NotImplementedException();
        }

        public Task<T> Set(T value)
        {
            throw new System.NotImplementedException();
        }
    }
}