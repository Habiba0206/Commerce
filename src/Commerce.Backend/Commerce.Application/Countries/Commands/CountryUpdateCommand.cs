using Commerce.Application.Countries.Models;
using Commerce.Domain.Common.Commands;

namespace Commerce.Application.Countries.Commands;

public record CountryUpdateCommand : ICommand<CountryCreateUpdateDto>
{
    public CountryCreateUpdateDto CountryCreateUpdateDto { get; set; }
}
