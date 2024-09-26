using AutoMapper;
using QuickLink.Application.Entities;

namespace QuickLink.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ShortLink, Models.ShortLink>().ReverseMap();
        }
    }
}
