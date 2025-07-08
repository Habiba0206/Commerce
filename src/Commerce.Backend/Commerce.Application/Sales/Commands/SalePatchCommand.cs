using Commerce.Application.Sales.Models;
using Commerce.Domain.Common.Commands;

namespace Commerce.Application.Sales.Commands;

public record SalePatchCommand : ICommand<SalePatchDto>
{
    public SalePatchDto SalePatchDto { get; set; } = null!;
}