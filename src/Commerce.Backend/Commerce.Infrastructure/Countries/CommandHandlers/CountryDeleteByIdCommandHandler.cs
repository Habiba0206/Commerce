using Commerce.Application.Countries.Commands;
using Commerce.Application.Countries.Services;
using Commerce.Domain.Common.Commands;

namespace Commerce.Infrastructure.Countries.CommandHandlers;

public class CountryDeleteByIdCommandHandler(
    ICountryService service)
    : ICommandHandler<CountryDeleteByIdCommand, bool>
{
    public async Task<bool> Handle(CountryDeleteByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await service.DeleteByIdAsync(request.CountryId, cancellationToken: cancellationToken);
        return result is not null;
    }
}