using System.Threading.Tasks;

namespace GpioDevicesService.Services.Interfaces
{
    public interface ICacheService<T>
    {
        Task<T> Get();
        Task<T> Set(T value);
    }
}