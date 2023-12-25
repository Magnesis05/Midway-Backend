using AutoMapper;
using Backend.Dto;
using Backend.Models;

namespace Backend.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<User, AllergiesDto>();
            CreateMap<Allergies, AllergiesDto>();
            CreateMap<AllergiesDto, Allergies>();

        }
    }
}
