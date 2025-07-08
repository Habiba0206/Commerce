using AutoMapper;
using Commerce.Application.Countries.Models;
using Commerce.Application.Countries.Queries;
using Commerce.Application.Countries.Services;
using Commerce.Domain.Common.Queries;
using Commerce.Infrastructure.Common.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Infrastructure.Countries.QueryHandlers;

public class CountryGetQueryHandler(
    IMapper mapper,
    ICountryService service,
    GetQueryValidator validationRules)
    : IQueryHandler<CountryGetQuery, ICollection<CountryGetDto>>
{
    public async Task<ICollection<CountryGetDto>> Handle(CountryGetQuery request, CancellationToken cancellationToken)
    {
        var pagination = request.CountryFilter ?? new CountryFilter();
        var validationResult = await validationRules.ValidateAsync(pagination);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var result = await service.Get(
            request.CountryFilter,
            new QueryOptions { QueryTrackingMode = QueryTrackingMode.AsNoTracking })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<CountryGetDto>>(result);
    }
}