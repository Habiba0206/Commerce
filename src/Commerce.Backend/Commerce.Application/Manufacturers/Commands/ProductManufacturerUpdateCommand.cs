using Commerce.Application.Manufacturers.Models;
using Commerce.Domain.Common.Commands;

namespace Commerce.Application.Manufacturers.Commands;

public record ProductManufacturerUpdateCommand : ICommand<ProductManufacturerCreateUpdateDto>
{
    public ProductManufacturerCreateUpdateDto ProductManufacturerCreateUpdateDto { get; set; }
}