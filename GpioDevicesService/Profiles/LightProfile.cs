using AutoMapper;
using GpioDevicesService.Models;

namespace GpioDevicesService.Profiles
{
    public class LightProfile : Profile
    {
        public LightProfile()
        {
            CreateMap<LightRecord, LightReply>()
            .ForMember(dest => dest.Mode,
            opt => opt.MapFrom(src => src.Mode))
            .ForMember(dest => dest.Brightness,
            opt => opt.MapFrom(src => src.Brightness));
        }
    }
}