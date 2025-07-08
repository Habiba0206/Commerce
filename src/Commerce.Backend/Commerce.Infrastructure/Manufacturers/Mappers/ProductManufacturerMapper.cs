using AutoMapper;
using Commerce.Application.Manufacturers.Models;
using Commerce.Domain.Entities;

namespace Commerce.Infrastructure.Manufacturers.Mappers;

public class ProductManufacturerMapper : Profile
{
    public ProductManufacturerMapper()
    {
        CreateMap<ProductManufacturer, ProductManufacturerCreateUpdateDto>().ReverseMap();
        CreateMap<ProductManufacturer, ProductManufacturerGetDto>().ReverseMap();
        CreateMap<ProductManufacturer, ProductManufacturerPatchDto>().ReverseMap();
    }
}