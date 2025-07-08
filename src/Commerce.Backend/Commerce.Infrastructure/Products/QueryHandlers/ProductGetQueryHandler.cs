using AutoMapper;
using Commerce.Application.Products.Models;
using Commerce.Application.Products.Queries;
using Commerce.Application.Products.Services;
using Commerce.Domain.Common.Queries;
using Commerce.Infrastructure.Common.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Infrastructure.Products.QueryHandlers;

public class ProductGetQueryHandler(
    IMapper mapper,
    IProductService service,
    GetQueryValidator validationRules)
    : IQueryHandler<ProductGetQuery, ICollection<ProductGetDto>>
{
    public async Task<ICollection<ProductGetDto>> Handle(ProductGetQuery request, CancellationToken cancellationToken)
    {
        var pagination = request.ProductFilter ?? new ProductFilter();
        var validationResult = await validationRules.ValidateAsync(pagination);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var result = await service.Get(
            request.ProductFilter,
            new QueryOptions { QueryTrackingMode = QueryTrackingMode.AsNoTracking })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<ProductGetDto>>(result);
    }
}