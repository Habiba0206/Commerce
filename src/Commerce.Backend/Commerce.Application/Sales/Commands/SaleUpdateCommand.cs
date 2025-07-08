using Commerce.Application.Sales.Models;
using Commerce.Domain.Common.Commands;

namespace Commerce.Application.Sales.Commands;

public record SaleUpdateCommand : ICommand<SaleCreateUpdateDto>
{
    public SaleCreateUpdateDto SaleCreateUpdateDto { get; set; }
}