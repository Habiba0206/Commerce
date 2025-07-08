using Commerce.Application.Sections.Commands;
using Commerce.Application.Sections.Models;
using Commerce.Domain.Common.Commands;
using Commerce.Domain.Common.Queries;
using Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace Commerce.Application.Sections.Services;

public interface ISectionService
{
    IQueryable<Section> Get(
        Expression<Func<Section, bool>>? predicate = default, 
        QueryOptions queryOptions = default);
    
    IQueryable<Section> Get(
        SectionFilter filter, 
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
        Section item, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default);
    
    ValueTask<Section> UpdateAsync(
        Section item, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default);
    
    ValueTask<Section> PatchAsync(
        SectionPatchDto patchDto, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default);
    
    ValueTask<Section?> DeleteAsync(
        Section item, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default);
    
    ValueTask<Section?> DeleteByIdAsync(
        Guid id, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default);
}
