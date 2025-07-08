using Commerce.Domain.Common.Commands;

namespace Commerce.Application.Sales.Commands;

public record SaleDeleteByIdCommand : ICommand<bool>
{
    public Guid SaleId { get; set; }
}
