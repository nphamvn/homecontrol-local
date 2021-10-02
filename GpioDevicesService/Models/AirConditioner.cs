namespace GpioDevicesService.Models
{
    public class AirConditioner
    {
        public int Temperature { get; set; }
        public string Mode { get; set; }
    }

    public record AirConditionerRecord(string Mode, int Temperature)
    {

    }
}