using AutoMapper;
using Commerce.Application.Products.Models;
using Commerce.Domain.Entities;

namespace Commerce.Infrastructure.Products.Mappers;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<Product, ProductCreateUpdateDto>().ReverseMap();
        CreateMap<Product, ProductGetDto>().ReverseMap();
        CreateMap<Product, ProductPatchDto>().ReverseMap();
    }
}