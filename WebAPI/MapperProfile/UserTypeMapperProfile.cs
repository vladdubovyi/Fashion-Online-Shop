using AutoMapper;
using DTOs.Create;
using DTOs.Get;
using DTOs.Update;
using Entities;

namespace MapperProfiles
{
    public class UserTypeMapperProfile : Profile
    {
        public UserTypeMapperProfile()
        {
            // source -> target
            CreateMap<UserTypeCreateDTO, UserType>();
            CreateMap<UserTypeUpdateDTO, UserType>();
            CreateMap<UserType, UserTypeGetDTO>();
        }
    }
}
