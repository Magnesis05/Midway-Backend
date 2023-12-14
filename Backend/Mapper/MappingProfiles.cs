using AutoMapper;
using Backend.Dto;
using Backend.Models;

namespace Backend.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Users, UsersDto>();
        }
    }
}
