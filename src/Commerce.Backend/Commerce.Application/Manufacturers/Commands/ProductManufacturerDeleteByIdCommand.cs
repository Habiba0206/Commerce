using Commerce.Domain.Common.Commands;

namespace Commerce.Application.Manufacturers.Commands;

public record ProductManufacturerDeleteByIdCommand : ICommand<bool>
{
    public Guid ProductManufacturerId { get; set; }
}