using AutoMapper;
using Commerce.Application.Sections.Models;
using Commerce.Domain.Entities;

namespace Commerce.Infrastructure.Sections.Mappers;

public class SectionMapper : Profile
{
    public SectionMapper()
    {
        CreateMap<Section, SectionCreateUpdateDto>().ReverseMap();
        CreateMap<Section, SectionGetDto>().ReverseMap();
        CreateMap<Section, SectionPatchDto>().ReverseMap();
    }
}