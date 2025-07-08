using AutoMapper;
using Commerce.Application.Categories.Models;
using Commerce.Application.Categories.Queries;
using Commerce.Application.Categories.Services;
using Commerce.Domain.Common.Queries;

namespace Commerce.Infrastructure.Categories.QueryHandlers;

public class CategoryGetByIdQueryHandler(
    IMapper mapper,
    ICategoryService service)
    : IQueryHandler<CategoryGetByIdQuery, CategoryGetDto>
{
    public async Task<CategoryGetDto> Handle(CategoryGetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await service.GetByIdAsync(request.CategoryId, cancellationToken: cancellationToken);
        return mapper.Map<CategoryGetDto>(result);
    }
}