using Commerce.Application.Manufacturers.Models;
using Commerce.Domain.Common.Queries;

namespace Commerce.Application.Manufacturers.Queries;

public record ProductManufacturerGetByIdQuery : IQuery<ProductManufacturerGetDto?>
{
    public Guid ProductManufacturerId { get; set; }
}
