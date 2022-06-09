using AutoMapper;
using DTOs.Create;
using DTOs.Get;
using DTOs.Update;
using Entities;
using System;

namespace MapperProfiles
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            // source -> target
            CreateMap<UserCreateDTO, User>()
                .ForPath(dest => dest.Type.Id, opt => opt.MapFrom(src => src.TypeId));
            CreateMap<UserUpdateDTO, User>();
            CreateMap<User, UserGetDTO>();
        }
    }
}
