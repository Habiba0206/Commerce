using AutoMapper;
using Commerce.Application.Countries.Models;
using Commerce.Domain.Entities;

namespace Commerce.Infrastructure.Countries.Mappers;

public class CountryMapper : Profile
{
    public CountryMapper()
    {
        CreateMap<Country, CountryCreateUpdateDto>().ReverseMap();
        CreateMap<Country, CountryGetDto>().ReverseMap();
        CreateMap<Country, CountryPatchDto>().ReverseMap();
    }
}