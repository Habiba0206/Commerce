using Commerce.Application.Sales.Models;
using Commerce.Application.Sales.Services;
using Commerce.Domain.Common.Commands;
using Commerce.Domain.Common.Exceptions;
using Commerce.Domain.Common.Queries;
using Commerce.Domain.Entities;
using Commerce.Persistence.Extensions;
using Commerce.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Commerce.Infrastructure.Sales.Services;

public class SaleService(
    ISaleRepository repository)
    : ISaleService
{
    public IQueryable<Sale> Get(
        Expression<Func<Sale, bool>>? predicate = null, 
        QueryOptions queryOptions = default) =>
        repository.Get(predicate, queryOptions);

    public IQueryable<Sale> Get(
        SaleFilter filter, 
        QueryOptions queryOptions = default) =>
        repository.Get(queryOptions: queryOptions)
        .ApplyPagination(filter);

    public ValueTask<Sale?> GetByIdAsync(
        Guid id, 
        QueryOptions queryOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<Sale>> GetByIdsAsync(
        IEnumerable<Guid> ids, 
        QueryOptions queryOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id, 
        CancellationToken cancellationToken = default) =>
        repository.CheckByIdAsync(id, cancellationToken);

    public ValueTask<Sale> CreateAsync(
        Sale entity, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.CreateAsync(entity, commandOptions, cancellationToken);

    public async ValueTask<Sale> UpdateAsync(
        Sale entity, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default)
    {
        var existing = await repository.GetByIdAsync(entity.Id) ?? throw new NotFoundException(nameof(Sale), entity.Id);
        
        existing.QuantitySold = entity.QuantitySold;
        existing.SalePrice = entity.SalePrice;
        existing.SaleDate = entity.SaleDate;
        existing.ProductId = entity.ProductId;
        
        return await repository.UpdateAsync(existing, commandOptions, cancellationToken);
    }

    public async ValueTask<Sale> PatchAsync(
        SalePatchDto patchDto, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default)
    {
        var existing = await repository.GetByIdAsync(patchDto.Id, cancellationToken: cancellationToken)
                      ?? throw new NotFoundException(nameof(Sale), patchDto.Id);

        if (patchDto.QuantitySold.HasValue) existing.QuantitySold = patchDto.QuantitySold.Value;
        if (patchDto.SalePrice.HasValue) existing.SalePrice = patchDto.SalePrice.Value;
        if (patchDto.SaleDate.HasValue) existing.SaleDate = patchDto.SaleDate.Value;
        if (patchDto.ProductId.HasValue) existing.ProductId = patchDto.ProductId.Value;

        return await repository.UpdateAsync(existing, cancellationToken: cancellationToken);
    }

    public ValueTask<Sale?> DeleteAsync(
        Sale entity, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.DeleteAsync(entity, commandOptions, cancellationToken);

    public ValueTask<Sale?> DeleteByIdAsync(
        Guid id, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.DeleteByIdAsync(id, commandOptions, cancellationToken);
}