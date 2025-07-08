using Commerce.Application.Products.Models;
using Commerce.Domain.Common.Queries;

namespace Commerce.Application.Products.Queries;

public record ProductGetByIdQuery : IQuery<ProductGetDto?>
{
    public Guid ProductId { get; set; }
}