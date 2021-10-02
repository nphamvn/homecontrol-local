using AutoMapper;
using GpioDevicesService.Models;

namespace GpioDevicesService.Profiles
{
    public class AirConditionerProfile : Profile
    {
        public AirConditionerProfile()
        {
            CreateMap<AirConditionerRecord, AirConditionerReply>()
            .ForMember(dest => dest.Mode,
            opt => opt.MapFrom(src => src.Mode))
            .ForMember(dest => dest.Temperature,
            opt => opt.MapFrom(src => src.Temperature));
        }
    }
}