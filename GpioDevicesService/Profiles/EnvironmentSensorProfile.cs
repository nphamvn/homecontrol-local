using AutoMapper;
using GpioDevicesService.Models;

namespace GpioDevicesService.Profiles
{
    public class EnvironmentSensorProfile : Profile
    {
        public EnvironmentSensorProfile()
        {
            CreateMap<EnvironmentSensorRecord, EnvironmentSensorReply>()
            .ForMember(dest => dest.Temperature,
            opt => opt.MapFrom(src => src.Temperature))
            .ForMember(dest => dest.Humindity,
            opt => opt.MapFrom(src => src.Humidity));
        }
    }
}