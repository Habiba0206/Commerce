using Commerce.Domain.Common.Commands;
using Commerce.Domain.Common.Queries;
using Commerce.Domain.Entities;
using Commerce.Persistence.Caching.Brokers;
using Commerce.Persistence.DataContexts;
using Commerce.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Commerce.Persistence.Repositories;

public class ProductManufacturerRepository(AppDbContext appDbContext, ICacheBroker cacheBroker) :
    EntityRepositoryBase<ProductManufacturer, AppDbContext>(appDbContext, cacheBroker),
    IProductManufacturerRepository
{
    public IQueryable<ProductManufacturer> Get(
        Expression<Func<ProductManufacturer, bool>>? predicate = null,
        QueryOptions queryOptions = default) =>
    base.Get(predicate, queryOptions);

    public ValueTask<ProductManufacturer?> GetByIdAsync(Guid id, QueryOptions queryOptions = default, CancellationToken cancellationToken = default) =>
        base.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<ProductManufacturer>> GetByIdsAsync(IEnumerable<Guid> ids, QueryOptions queryOptions = default, CancellationToken cancellationToken = default) =>
        base.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        base.CheckByIdAsync(id, cancellationToken);

    public ValueTask<ProductManufacturer> CreateAsync(ProductManufacturer entity, CommandOptions commandOptions = default, CancellationToken cancellationToken = default) =>
        base.CreateAsync(entity, commandOptions, cancellationToken);

    public ValueTask<ProductManufacturer> UpdateAsync(ProductManufacturer entity, CommandOptions commandOptions, CancellationToken cancellationToken) =>
        base.UpdateAsync(entity, commandOptions, cancellationToken);

    public ValueTask<ProductManufacturer?> DeleteAsync(ProductManufacturer entity, CommandOptions commandOptions, CancellationToken cancellationToken = default) =>
        base.DeleteAsync(entity, commandOptions, cancellationToken);

    public ValueTask<ProductManufacturer?> DeleteByIdAsync(Guid id, CommandOptions commandOptions, CancellationToken cancellationToken = default) =>
        base.DeleteByIdAsync(id, commandOptions, cancellationToken);
}

