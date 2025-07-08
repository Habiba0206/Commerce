using AutoMapper;
using Commerce.Application.Countries.Models;
using Commerce.Application.Countries.Queries;
using Commerce.Application.Countries.Services;
using Commerce.Domain.Common.Queries;

namespace Commerce.Infrastructure.Countries.QueryHandlers;

public class CountryGetByIdQueryHandler(
    IMapper mapper,
    ICountryService service)
    : IQueryHandler<CountryGetByIdQuery, CountryGetDto>
{
    public async Task<CountryGetDto> Handle(CountryGetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await service.GetByIdAsync(request.CountryId, cancellationToken: cancellationToken);
        return mapper.Map<CountryGetDto>(result);
    }
}