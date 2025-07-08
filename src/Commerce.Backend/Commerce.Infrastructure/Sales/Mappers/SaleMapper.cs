using AutoMapper;
using Commerce.Application.Sales.Models;
using Commerce.Domain.Entities;

namespace Commerce.Infrastructure.Sales.Mappers;

public class SaleMapper : Profile
{
    public SaleMapper()
    {
        CreateMap<Sale, SaleCreateUpdateDto>().ReverseMap();
        CreateMap<Sale, SaleGetDto>().ReverseMap();
        CreateMap<Sale, SalePatchDto>().ReverseMap();
    }
}