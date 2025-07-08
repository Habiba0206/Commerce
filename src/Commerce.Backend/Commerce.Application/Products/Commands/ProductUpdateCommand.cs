using Commerce.Application.Products.Models;
using Commerce.Domain.Common.Commands;

namespace Commerce.Application.Products.Commands;

public record ProductUpdateCommand : ICommand<ProductCreateUpdateDto>
{
    public ProductCreateUpdateDto ProductCreateUpdateDto { get; set; }
}
