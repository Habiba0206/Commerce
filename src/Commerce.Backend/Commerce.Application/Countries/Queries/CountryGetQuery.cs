using Commerce.Application.Countries.Models;
using Commerce.Domain.Common.Queries;

namespace Commerce.Application.Countries.Queries;

public record CountryGetQuery : IQuery<ICollection<CountryGetDto>>
{
    public CountryFilter CountryFilter { get; set; }
}

