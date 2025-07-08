using AutoMapper;
using Commerce.Application.Categories.Models;
using Commerce.Domain.Entities;

namespace Commerce.Infrastructure.Categories.Mappers;

public class CategoryMapper : Profile
{
    public CategoryMapper()
    {
        CreateMap<Category, CategoryCreateUpdateDto>().ReverseMap();
        CreateMap<Category, CategoryGetDto>().ReverseMap();
        CreateMap<Category, CategoryPatchDto>().ReverseMap();
    }
}