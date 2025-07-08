using Commerce.Application.Manufacturers.Models;
using Commerce.Domain.Common.Queries;

namespace Commerce.Application.Manufacturers.Queries;

public record ProductManufacturerGetQuery : IQuery<ICollection<ProductManufacturerGetDto>>
{
    public ProductManufacturerFilter ProductManufacturerFilter { get; set; }
}
