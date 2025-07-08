using Commerce.Application.Manufacturers.Models;
using Commerce.Domain.Common.Commands;

namespace Commerce.Application.Manufacturers.Commands;

public record ProductManufacturerPatchCommand : ICommand<ProductManufacturerPatchDto>
{
    public ProductManufacturerPatchDto ProductManufacturerPatchDto { get; set; } = null!;
}
