using System.Threading.Tasks;
using GpioDevicesService.Services.Interfaces;
using Microsoft.Extensions.Caching.Distributed;

namespace GpioDevicesService.Services
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _distributedCache;

        public CacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public Task<T> Get<T>()
        {
            throw new System.NotImplementedException();
        }

        public Task<T> Set<T>(T value)
        {
            throw new System.NotImplementedException();
        }
    }
}