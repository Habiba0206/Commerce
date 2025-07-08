using Commerce.Application.Products.Models;
using Commerce.Domain.Common.Commands;
using Commerce.Domain.Common.Queries;
using Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace Commerce.Application.Products.Services;

public interface IProductService
{
    IQueryable<Product> Get(
        Expression<Func<Product, bool>>? predicate = default, 
        QueryOptions queryOptions = default);
    
    IQueryable<Product> Get(
        ProductFilter filter, 
        QueryOptions queryOptions = default);
    
    ValueTask<Product?> GetByIdAsync(
        Guid id, 
        QueryOptions queryOptions = default, 
        CancellationToken cancellationToken = default);
    
    ValueTask<bool> CheckByIdAsync(
        Guid id, 
        CancellationToken cancellationToken = default);
    
    ValueTask<IList<Product>> GetByIdsAsync(
        IEnumerable<Guid> ids, 
        QueryOptions queryOptions = default, 
        CancellationToken cancellationToken = default);
    
    ValueTask<Product> CreateAsync(
        Product product, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default);
    
    ValueTask<Product> UpdateAsync(
        Product product, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default);
    
    ValueTask<Product> PatchAsync(
        ProductPatchDto patchDto, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default);
    
    ValueTask<Product?> DeleteAsync(
        Product product, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default);
    
    ValueTask<Product?> DeleteByIdAsync(
        Guid id, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default);
}