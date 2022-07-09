using AutoMapper;
using DTOs.Create;
using DTOs.Get;
using DTOs.Post;
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
			CreateMap<UserCreateDTO, User>();
			CreateMap<UserUpdateDTO, User>();
			CreateMap<User, UserGetDTO>();

			CreateMap<UserLogin, User>();
			CreateMap<UserRegister, User>()
				.ForMember(dest => dest.PasswordHASH, src => src.MapFrom(opt => opt.Password));
		}
	}
}
