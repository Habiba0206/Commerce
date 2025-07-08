using Commerce.Application.Sections.Commands;
using Commerce.Application.Sections.Models;
using Commerce.Application.Sections.Services;
using Commerce.Domain.Common.Commands;
using Commerce.Domain.Common.Exceptions;
using Commerce.Domain.Common.Queries;
using Commerce.Domain.Entities;
using Commerce.Persistence.Extensions;
using Commerce.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Commerce.Infrastructure.Sections.Services;

public class SectionService(
    ISectionRepository repository)
    : ISectionService
{
    public IQueryable<Section> Get(
        Expression<Func<Section, bool>>? predicate = null, 
        QueryOptions queryOptions = default) =>
        repository.Get(predicate, queryOptions);

    public IQueryable<Section> Get(
        SectionFilter filter, 
        QueryOptions queryOptions = default) =>
        repository.Get(queryOptions: queryOptions).ApplyPagination(filter);

    public ValueTask<Section?> GetByIdAsync(
        Guid id, 
        QueryOptions queryOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<Section>> GetByIdsAsync(
        IEnumerable<Guid> ids, 
        QueryOptions queryOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id, 
        CancellationToken cancellationToken = default) =>
        repository.CheckByIdAsync(id, cancellationToken);

    public ValueTask<Section> CreateAsync(
        Section entity, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.CreateAsync(entity, commandOptions, cancellationToken);

    public async ValueTask<Section> UpdateAsync(
        Section entity, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default)
    {
        var existing = await repository.GetByIdAsync(entity.Id) ?? throw new NotFoundException(nameof(Section), entity.Id);
        
        existing.Name = entity.Name;
        
        return await repository.UpdateAsync(existing, commandOptions, cancellationToken);
    }

    public async ValueTask<Section> PatchAsync(
        SectionPatchDto patchDto, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default)
    {
        var existing = await repository.GetByIdAsync(patchDto.Id, cancellationToken: cancellationToken)
                      ?? throw new NotFoundException(nameof(Section), patchDto.Id);
        
        if (patchDto.Name is not null) existing.Name = patchDto.Name;
        
        return await repository.UpdateAsync(existing, cancellationToken: cancellationToken);
    }

    public ValueTask<Section?> DeleteAsync(
        Section entity, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.DeleteAsync(entity, commandOptions, cancellationToken);

    public ValueTask<Section?> DeleteByIdAsync(
        Guid id, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.DeleteByIdAsync(id, commandOptions, cancellationToken);
}