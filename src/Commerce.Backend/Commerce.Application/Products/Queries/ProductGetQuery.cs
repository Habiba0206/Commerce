using Commerce.Application.Products.Models;
using Commerce.Domain.Common.Queries;

namespace Commerce.Application.Products.Queries;

public record ProductGetQuery : IQuery<ICollection<ProductGetDto>>
{
    public ProductFilter ProductFilter { get; set; }
}