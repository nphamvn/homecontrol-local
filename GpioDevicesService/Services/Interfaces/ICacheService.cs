using System.Threading.Tasks;

namespace GpioDevicesService.Services.Interfaces
{
    public interface ICacheService
    {
        Task<T> Get<T>();
        Task<T> Set<T>(T value);
    }
}