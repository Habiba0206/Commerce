using Commerce.Application.Countries.Models;
using Commerce.Domain.Common.Commands;

namespace Commerce.Application.Countries.Commands;

public record CountryPatchCommand : ICommand<CountryPatchDto>
{
    public CountryPatchDto CountryPatchDto { get; set; } = null!;
}
