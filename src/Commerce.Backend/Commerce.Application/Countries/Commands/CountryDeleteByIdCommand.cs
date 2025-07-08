using Commerce.Domain.Common.Commands;

namespace Commerce.Application.Countries.Commands;

public record CountryDeleteByIdCommand : ICommand<bool>
{
    public Guid CountryId { get; set; }
}
