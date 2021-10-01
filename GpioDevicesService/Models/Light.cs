namespace GpioDevicesService.Models
{
    public class Light
    {
        public int Brightness { get; set; }
        public string Mode { get; set; }
    }

    public record LightRecord(int Brightness, string Mode)
    {
    }
}