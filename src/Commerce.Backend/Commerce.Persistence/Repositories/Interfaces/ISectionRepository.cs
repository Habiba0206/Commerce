using Commerce.Domain.Common.Commands;
using Commerce.Domain.Common.Queries;
using Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace Commerce.Persistence.Repositories.Interfaces;

public interface ISectionRepository
{
    IQueryable<Section> Get(
        Expression<Func<Section, bool>>? predicate = default,
        QueryOptions queryOptions = default);

    ValueTask<Section?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    ValueTask<IList<Section>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Section> CreateAsync(
        Section section,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Section> UpdateAsync(
        Section section,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Section?> DeleteAsync(
        Section section,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Section?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);
}
