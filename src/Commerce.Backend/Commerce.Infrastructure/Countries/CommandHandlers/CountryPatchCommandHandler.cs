using AutoMapper;
using Commerce.Application.Countries.Commands;
using Commerce.Application.Countries.Models;
using Commerce.Application.Countries.Services;
using Commerce.Domain.Common.Commands;

namespace Commerce.Infrastructure.Countries.CommandHandlers;

public class CountryPatchCommandHandler(
    ICountryService service,
    IMapper mapper)
    : ICommandHandler<CountryPatchCommand, CountryPatchDto>
{
    public async Task<CountryPatchDto> Handle(CountryPatchCommand request, CancellationToken cancellationToken)
    {
        var entity = await service.PatchAsync(request.CountryPatchDto, cancellationToken: cancellationToken);
        return mapper.Map<CountryPatchDto>(entity);
    }
}