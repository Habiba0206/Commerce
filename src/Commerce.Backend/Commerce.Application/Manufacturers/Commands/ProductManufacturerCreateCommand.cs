using Commerce.Application.Manufacturers.Models;
using Commerce.Domain.Common.Commands;

namespace Commerce.Application.Manufacturers.Commands;

public record ProductManufacturerCreateCommand : ICommand<ProductManufacturerCreateUpdateDto>
{
    public ProductManufacturerCreateUpdateDto ProductManufacturerCreateUpdateDto { get; set; }
}