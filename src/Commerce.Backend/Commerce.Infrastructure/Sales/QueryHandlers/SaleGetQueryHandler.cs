using AutoMapper;
using Commerce.Application.Sales.Models;
using Commerce.Application.Sales.Queries;
using Commerce.Application.Sales.Services;
using Commerce.Domain.Common.Queries;
using Commerce.Infrastructure.Common.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Infrastructure.Sales.QueryHandlers;

public class SaleGetQueryHandler(
    IMapper mapper,
    ISaleService service,
    GetQueryValidator validationRules)
    : IQueryHandler<SaleGetQuery, ICollection<SaleGetDto>>
{
    public async Task<ICollection<SaleGetDto>> Handle(SaleGetQuery request, CancellationToken cancellationToken)
    {
        var pagination = request.SaleFilter ?? new SaleFilter();
        var validationResult = await validationRules.ValidateAsync(pagination);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var result = await service.Get(
            request.SaleFilter,
            new QueryOptions { QueryTrackingMode = QueryTrackingMode.AsNoTracking })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<SaleGetDto>>(result);
    }
}