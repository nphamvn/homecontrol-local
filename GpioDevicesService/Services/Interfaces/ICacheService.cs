using System.Threading.Tasks;

namespace GpioDevicesService.Services.Interfaces
{
    public interface ICacheService
    {
        Task<T> Get<T>(string key);
        Task Set<T>(string key, T value);
    }
}