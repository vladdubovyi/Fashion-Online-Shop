using AutoMapper;
using DTOs.Create;
using DTOs.Get;
using DTOs.Update;
using Entities;
using System;

namespace MapperProfiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // source -> target
            CreateMap<CategoryCreateDTO, Category>();
            CreateMap<CategoryUpdateDTO, Category>();
            CreateMap<Category, CategoryGetDTO>();

            CreateMap<TagCreateDTO, Tag>();
            CreateMap<TagUpdateDTO, Tag>();
            CreateMap<Tag, TagGetDTO>();

            CreateMap<UserTypeCreateDTO, UserType>();
            CreateMap<UserTypeUpdateDTO, UserType>();
            CreateMap<UserType, UserTypeGetDTO>();
        }
    }
}
