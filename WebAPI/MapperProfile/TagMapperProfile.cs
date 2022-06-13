using AutoMapper;
using DTOs.Create;
using DTOs.Get;
using DTOs.Update;
using Entities;

namespace MapperProfiles
{
    public class TagMapperProfile : Profile
    {
        public TagMapperProfile()
        {
            // source -> target
            CreateMap<TagCreateDTO, Tag>();
            CreateMap<TagUpdateDTO, Tag>();
            CreateMap<Tag, TagGetDTO>();
        }
    }
}
