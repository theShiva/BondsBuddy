using AutoMapper;
using BondsBuddy.Api.Models;
using BondsBuddy.Api.Models.Dtos;
using BondsBuddy.Core.Models;

namespace BondsBuddy.Api
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<PhoneDto, Phone>().ReverseMap()
                    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.NationalFormattedPhoneNumber));

                config.CreateMap<PhoneForCreationDto, Phone>().ReverseMap();

                config.CreateMap<CanonicalPhoneNumber, Phone>().ReverseMap();
            });
        }
    }
}