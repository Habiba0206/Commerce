using AutoMapper;
using Commerce.Application.Products.Models;
using Commerce.Application.Products.Queries;
using Commerce.Application.Products.Services;
using Commerce.Domain.Common.Queries;

namespace Commerce.Infrastructure.Products.QueryHandlers;

public class ProductGetByIdQueryHandler(
    IMapper mapper,
    IProductService service)
    : IQueryHandler<ProductGetByIdQuery, ProductGetDto>
{
    public async Task<ProductGetDto> Handle(ProductGetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await service.GetByIdAsync(request.ProductId, cancellationToken: cancellationToken);
        return mapper.Map<ProductGetDto>(result);
    }
}