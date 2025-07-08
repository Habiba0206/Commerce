using Commerce.Application.Manufacturers.Models;
using Commerce.Application.Manufacturers.Services;
using Commerce.Domain.Common.Commands;
using Commerce.Domain.Common.Exceptions;
using Commerce.Domain.Common.Queries;
using Commerce.Domain.Entities;
using Commerce.Persistence.Extensions;
using Commerce.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Commerce.Infrastructure.Manufacturers.Services;

public class ProductManufacturerService(
    IProductManufacturerRepository repository)
    : IProductManufacturerService
{
    public IQueryable<ProductManufacturer> Get(
        Expression<Func<ProductManufacturer, bool>>? predicate = null, 
        QueryOptions queryOptions = default) =>
        repository.Get(predicate, queryOptions);

    public IQueryable<ProductManufacturer> Get(
        ProductManufacturerFilter filter, 
        QueryOptions queryOptions = default) =>
        repository.Get(queryOptions: queryOptions).ApplyPagination(filter);

    public ValueTask<ProductManufacturer?> GetByIdAsync(
        Guid id, 
        QueryOptions queryOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<ProductManufacturer>> GetByIdsAsync(
        IEnumerable<Guid> ids, 
        QueryOptions queryOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id, 
        CancellationToken cancellationToken = default) =>
        repository.CheckByIdAsync(id, cancellationToken);

    public ValueTask<ProductManufacturer> CreateAsync(
        ProductManufacturer entity, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.CreateAsync(entity, commandOptions, cancellationToken);

    public async ValueTask<ProductManufacturer> UpdateAsync(
        ProductManufacturer entity, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default)
    {
        var existing = await repository.GetByIdAsync(entity.Id) ?? throw new NotFoundException(nameof(ProductManufacturer), entity.Id);
        
        existing.Name = entity.Name;
        
        return await repository.UpdateAsync(existing, commandOptions, cancellationToken);
    }

    public async ValueTask<ProductManufacturer> PatchAsync(
        ProductManufacturerPatchDto patchDto, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default)
    {
        var existing = await repository.GetByIdAsync(patchDto.Id, cancellationToken: cancellationToken)
                      ?? throw new NotFoundException(nameof(ProductManufacturer), patchDto.Id);
        
        if (patchDto.Name is not null) existing.Name = patchDto.Name;
        
        return await repository.UpdateAsync(existing, cancellationToken: cancellationToken);
    }

    public ValueTask<ProductManufacturer?> DeleteAsync(
        ProductManufacturer entity, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.DeleteAsync(entity, commandOptions, cancellationToken);

    public ValueTask<ProductManufacturer?> DeleteByIdAsync(
        Guid id, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.DeleteByIdAsync(id, commandOptions, cancellationToken);
}