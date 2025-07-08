using AutoMapper;
using Commerce.Application.Categories.Models;
using Commerce.Application.Categories.Queries;
using Commerce.Application.Categories.Services;
using Commerce.Domain.Common.Queries;
using Commerce.Infrastructure.Common.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Infrastructure.Categories.QueryHandlers;

public class CategoryGetQueryHandler(
    IMapper mapper,
    ICategoryService service,
    GetQueryValidator validationRules)
    : IQueryHandler<CategoryGetQuery, ICollection<CategoryGetDto>>
{
    public async Task<ICollection<CategoryGetDto>> Handle(CategoryGetQuery request, CancellationToken cancellationToken)
    {
        var pagination = request.CategoryFilter ?? new CategoryFilter();
        var validationResult = await validationRules.ValidateAsync(pagination);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var result = await service.Get(
            request.CategoryFilter,
            new QueryOptions { QueryTrackingMode = QueryTrackingMode.AsNoTracking })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<CategoryGetDto>>(result);
    }
}