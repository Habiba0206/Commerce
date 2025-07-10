using Commerce.Application.Products.Models;
using Commerce.Application.Products.Services;
using Commerce.Domain.Common.Commands;
using Commerce.Domain.Common.Exceptions;
using Commerce.Domain.Common.Queries;
using Commerce.Domain.Entities;
using Commerce.Persistence.Extensions;
using Commerce.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Commerce.Infrastructure.Products.Services;

public class ProductService(
    IProductRepository repository)
    : IProductService
{
    public IQueryable<Product> Get(
        Expression<Func<Product, bool>>? predicate = null, 
        QueryOptions queryOptions = default) =>
        repository.Get(predicate, queryOptions);

    public IQueryable<Product> Get(
        ProductFilter filter,
        QueryOptions queryOptions = default) =>
    ApplyFilter(repository.Get(queryOptions: queryOptions), filter).ApplyPagination(filter); 

    public ValueTask<Product?> GetByIdAsync(
        Guid id, 
        QueryOptions queryOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<Product>> GetByIdsAsync(
        IEnumerable<Guid> ids, 
        QueryOptions queryOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id, 
        CancellationToken cancellationToken = default) =>
        repository.CheckByIdAsync(id, cancellationToken);

    public ValueTask<Product> CreateAsync(
        Product entity, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.CreateAsync(entity, commandOptions, cancellationToken);

    public async ValueTask<Product> UpdateAsync(
        Product entity, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default)
    {
        var existing = await repository.GetByIdAsync(entity.Id) ?? throw new NotFoundException(nameof(Product), entity.Id);

        existing.MetaTitle = entity.MetaTitle;
        existing.Model = entity.Model;
        existing.IdentificationNumber = entity.IdentificationNumber;
        existing.Priority = entity.Priority;
        existing.Link = entity.Link;
        existing.MetaTags = entity.MetaTags;
        existing.MetaDescription = entity.MetaDescription;
        existing.Price = entity.Price;
        existing.Extra = entity.Extra;
        existing.Profit = entity.Profit;
        existing.Warehouse = entity.Warehouse;
        existing.Amount = entity.Amount;
        existing.Availability = entity.Availability;
        existing.Description = entity.Description;
        existing.ImageUrl = entity.ImageUrl;
        existing.Views = entity.Views;
        existing.ProductManufacturerId = entity.ProductManufacturerId;
        existing.SectionId = entity.SectionId;
        existing.CategoryId = entity.CategoryId;
        existing.CountryId = entity.CountryId;

        return await repository.UpdateAsync(existing, commandOptions, cancellationToken);
    }

    public async ValueTask<Product> PatchAsync(
        ProductPatchDto patchDto, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default)
    {
        var existing = await repository.GetByIdAsync(patchDto.Id, cancellationToken: cancellationToken)
                      ?? throw new NotFoundException(nameof(Product), patchDto.Id);

        if (patchDto.MetaTitle is not null) existing.MetaTitle = patchDto.MetaTitle;
        if (patchDto.Model is not null) existing.Model = patchDto.Model;
        if (patchDto.IdentificationNumber is not null) existing.IdentificationNumber = patchDto.IdentificationNumber;
        if (patchDto.Priority.HasValue) existing.Priority = patchDto.Priority.Value;
        if (patchDto.Link is not null) existing.Link = patchDto.Link;
        if (patchDto.MetaTags is not null) existing.MetaTags = patchDto.MetaTags;
        if (patchDto.MetaDescription is not null) existing.MetaDescription = patchDto.MetaDescription;
        if (patchDto.Price.HasValue) existing.Price = patchDto.Price.Value;
        if (patchDto.Extra.HasValue) existing.Extra = patchDto.Extra.Value;
        if (patchDto.Profit.HasValue) existing.Profit = patchDto.Profit.Value;
        if (patchDto.Warehouse is not null) existing.Warehouse = patchDto.Warehouse;
        if (patchDto.Amount.HasValue) existing.Amount = patchDto.Amount.Value;
        if (patchDto.Availability.HasValue) existing.Availability = patchDto.Availability.Value;
        if (patchDto.Description is not null) existing.Description = patchDto.Description;
        if (patchDto.ImageUrl is not null) existing.ImageUrl = patchDto.ImageUrl;
        if (patchDto.Views.HasValue) existing.Views = patchDto.Views.Value;
        if (patchDto.ProductManufacturerId.HasValue) existing.ProductManufacturerId = patchDto.ProductManufacturerId.Value;
        if (patchDto.SectionId.HasValue) existing.SectionId = patchDto.SectionId.Value;
        if (patchDto.CategoryId.HasValue) existing.CategoryId = patchDto.CategoryId.Value;
        if (patchDto.CountryId.HasValue) existing.CountryId = patchDto.CountryId.Value;

        return await repository.UpdateAsync(existing, cancellationToken: cancellationToken);
    }

    public ValueTask<Product?> DeleteAsync(
        Product entity, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.DeleteAsync(entity, commandOptions, cancellationToken);

    public ValueTask<Product?> DeleteByIdAsync(
        Guid id, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.DeleteByIdAsync(id, commandOptions, cancellationToken);

    private IQueryable<Product> ApplyFilter(
    IQueryable<Product> query,
    ProductFilter filter)
    {
        if (filter.MinimumPrice.HasValue)
            query = query.Where(p => p.Price >= filter.MinimumPrice.Value);

        if (filter.MaximumPrice.HasValue)
            query = query.Where(p => p.Price <= filter.MaximumPrice.Value);

        if (filter.ProductManufacturerIds.Any())
            query = query.Where(p => filter.ProductManufacturerIds.Contains(p.ProductManufacturerId));

        if (filter.SectionIds.Any())
            query = query.Where(p => filter.SectionIds.Contains(p.SectionId));

        if (filter.CategoryIds.Any())
            query = query.Where(p => filter.CategoryIds.Contains(p.CategoryId));

        return query;
    }

}