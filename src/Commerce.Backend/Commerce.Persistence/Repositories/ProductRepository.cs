using Commerce.Domain.Common.Commands;
using Commerce.Domain.Common.Queries;
using Commerce.Domain.Entities;
using Commerce.Persistence.Caching.Brokers;
using Commerce.Persistence.DataContexts;
using Commerce.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Commerce.Persistence.Repositories;

public class ProductRepository(AppDbContext appDbContext, ICacheBroker cacheBroker) :
    EntityRepositoryBase<Product, AppDbContext>(appDbContext, cacheBroker),
    IProductRepository
{
    public IQueryable<Product> Get(
        Expression<Func<Product, bool>>? predicate = null,
        QueryOptions queryOptions = default) =>
    base.Get(predicate, queryOptions)
        .Include(p => p.ProductManufacturer)
        .Include(p => p.Section)
        .Include(p => p.Category)
        .Include(p => p.Country);

    public ValueTask<Product?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    base.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<Product>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    base.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default) =>
    base.CheckByIdAsync(id, cancellationToken);

    public ValueTask<Product> CreateAsync(
        Product product,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    base.CreateAsync(product, commandOptions, cancellationToken);

    public ValueTask<Product> UpdateAsync(
        Product product,
        CommandOptions commandOptions,
        CancellationToken cancellationToken) =>
    base.UpdateAsync(product, commandOptions, cancellationToken);

    public ValueTask<Product?> DeleteAsync(
        Product product,
        CommandOptions commandOptions,
        CancellationToken cancellationToken = default) =>
    base.DeleteAsync(product, commandOptions, cancellationToken);

    public ValueTask<Product?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions,
        CancellationToken cancellationToken = default) =>
    base.DeleteByIdAsync(id, commandOptions, cancellationToken);
}
