using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GpioDevicesService.Services.Interfaces;
using Microsoft.Extensions.Caching.Distributed;

namespace GpioDevicesService.Services
{
    public class RedisCacheService : ICacheService
    {
        private readonly IDistributedCache _cache;

        public RedisCacheService(IDistributedCache cache)
        {
            _cache = cache;
        }
        public async Task<T> Get<T>(string key)
        {
            var value = await _cache.GetAsync(key);
            string serializedValue;
            if (value != null)
            {
                serializedValue = Encoding.UTF8.GetString(value);
                return JsonSerializer.Deserialize<T>(serializedValue);
            }
            else
            {
                return default;
            }
        }

        public async Task Set<T>(string key, T value)
        {
            string stringValue = JsonSerializer.Serialize<T>(value);
            var bytesValue = Encoding.UTF8.GetBytes(stringValue);
            await _cache.SetAsync(key, bytesValue);
        }
    }
}