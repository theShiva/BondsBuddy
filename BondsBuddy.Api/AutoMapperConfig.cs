using AutoMapper;
using BondsBuddy.Api.Models;
using BondsBuddy.Api.Models.Dtos;

namespace BondsBuddy.Api
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<PhoneDto, Phone>().ReverseMap();
                config.CreateMap<PhoneForCreationDto, Phone>().ReverseMap();
            });
        }
    }
}