using Commerce.Application.Countries.Models;
using Commerce.Domain.Common.Queries;

namespace Commerce.Application.Countries.Queries;

public record CountryGetByIdQuery : IQuery<CountryGetDto?>
{
    public Guid CountryId { get; set; }
}