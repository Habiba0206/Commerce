using Commerce.Domain.Common.Commands;
using Commerce.Domain.Common.Queries;
using Commerce.Domain.Entities;
using Commerce.Persistence.Caching.Brokers;
using Commerce.Persistence.DataContexts;
using Commerce.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Commerce.Persistence.Repositories;

public class SectionRepository(AppDbContext appDbContext, ICacheBroker cacheBroker) :
    EntityRepositoryBase<Section, AppDbContext>(appDbContext, cacheBroker),
    ISectionRepository
{
    public IQueryable<Section> Get(
        Expression<Func<Section, bool>>? predicate = null,
        QueryOptions queryOptions = default) =>
    base.Get(predicate, queryOptions);

    public ValueTask<Section?> GetByIdAsync(Guid id, QueryOptions queryOptions = default, CancellationToken cancellationToken = default) =>
        base.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<Section>> GetByIdsAsync(IEnumerable<Guid> ids, QueryOptions queryOptions = default, CancellationToken cancellationToken = default) =>
        base.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        base.CheckByIdAsync(id, cancellationToken);

    public ValueTask<Section> CreateAsync(Section entity, CommandOptions commandOptions = default, CancellationToken cancellationToken = default) =>
        base.CreateAsync(entity, commandOptions, cancellationToken);

    public ValueTask<Section> UpdateAsync(Section entity, CommandOptions commandOptions, CancellationToken cancellationToken) =>
        base.UpdateAsync(entity, commandOptions, cancellationToken);

    public ValueTask<Section?> DeleteAsync(Section entity, CommandOptions commandOptions, CancellationToken cancellationToken = default) =>
        base.DeleteAsync(entity, commandOptions, cancellationToken);

    public ValueTask<Section?> DeleteByIdAsync(Guid id, CommandOptions commandOptions, CancellationToken cancellationToken = default) =>
        base.DeleteByIdAsync(id, commandOptions, cancellationToken);
}
