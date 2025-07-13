using Microsoft.EntityFrameworkCore;
using Commerce.Domain.Entities;
using Commerce.Persistence.DataContexts;

namespace Commerce.Api.Data;

public static class SeedDataExtensions
{
    public static async ValueTask InitializeSeedAsync(this IServiceProvider provider)
    {
        var db = provider.GetRequiredService<AppDbContext>();

        if (!await db.Products.AnyAsync())
            await db.SeedCommerceDemoAsync();

        if (db.ChangeTracker.HasChanges())
            await db.SaveChangesAsync();
    }

    private static async ValueTask SeedCommerceDemoAsync(this AppDbContext db)
    {
        var usa = new Country { Name = "United States" };
        var uzbek = new Country { Name = "Uzbekistan" };
        var china = new Country { Name = "China" };

        var phoneMfr = new ProductManufacturer { Name = "Phonix" };
        var shoeMfr = new ProductManufacturer { Name = "RunFast Inc." };

        var electronics = new Section { Name = "Electronics" };
        var fashion = new Section { Name = "Fashion" };

        var mobiles = new Category { Name = "Mobile Phones" };
        var sneakers = new Category { Name = "Sneakers" };

        var phonixX1 = new Product
        {
            MetaTitle = "Phonix X1",
            Model = "X1‑128GB‑Blk",
            IdentificationNumber = "PX1‑128‑BLK",
            Priority = 1,
            Link = "#",
            MetaTags = "phone, 5G",
            MetaDescription = "The latest Phonix with 5 nm chip.",
            Price = 799,
            Extra = 10,
            Profit = 250,
            Warehouse = "WH‑NYC",
            Amount = 500,
            Availability = true,
            Description = "Flagship device",
            ImageUrl = "https://via.placeholder.com/200x300?text=Phonix+X1",
            Views = 1400,
            ProductManufacturer = phoneMfr,
            Section = electronics,
            Category = mobiles,
            Country = usa
        };

        var phonixA2 = new Product
        {
            MetaTitle = "Phonix A2",
            Model = "A2‑64GB‑Blue",
            IdentificationNumber = "PX-A2-64-BL",
            Priority = 3,
            Link = "#",
            MetaTags = "budget phone",
            MetaDescription = "Affordable 5G handset.",
            Price = 379,
            Extra = 15,
            Profit = 110,
            Warehouse = "WH‑NYC",
            Amount = 900,
            Availability = true,
            Description = "Budget model",
            ImageUrl = "https://via.placeholder.com/200x300?text=Phonix+A2",
            Views = 400,
            ProductManufacturer = phoneMfr,
            Section = electronics,
            Category = mobiles,
            Country = usa
        };

        var tabletZ = new Product
        {
            MetaTitle = "Phonix Tab Z",
            Model = "TZ‑11‑256GB",
            IdentificationNumber = "PX-TZ‑256",
            Priority = 4,
            Link = "#",
            MetaTags = "tablet",
            MetaDescription = "Powerful tablet.",
            Price = 599,
            Extra = 12,
            Profit = 180,
            Warehouse = "WH‑NYC",
            Amount = 200,
            Availability = true,
            Description = "Flagship tablet",
            ImageUrl = "https://via.placeholder.com/200x300?text=Tab+Z",
            Views = 250,
            ProductManufacturer = phoneMfr,
            Section = electronics,
            Category = mobiles,
            Country = usa
        };

        var smartWatch = new Product
        {
            MetaTitle = "Phonix Watch S",
            Model = "PWS‑44",
            IdentificationNumber = "PX-WATCH‑S",
            Priority = 5,
            Link = "#",
            MetaTags = "watch",
            MetaDescription = "Smart watch.",
            Price = 199,
            Extra = 8,
            Profit = 60,
            Warehouse = "WH‑NYC",
            Amount = 450,
            Availability = true,
            Description = "Fitness watch",
            ImageUrl = "https://via.placeholder.com/200x300?text=Watch+S",
            Views = 520,
            ProductManufacturer = phoneMfr,
            Section = electronics,
            Category = mobiles,
            Country = usa
        };

        var earbuds = new Product
        {
            MetaTitle = "Phonix Buds Pro",
            Model = "PB‑PRO",
            IdentificationNumber = "PX-BUDS-PRO",
            Priority = 6,
            Link = "#",
            MetaTags = "earbuds",
            MetaDescription = "Wireless earbuds.",
            Price = 149,
            Extra = 6,
            Profit = 40,
            Warehouse = "WH‑NYC",
            Amount = 600,
            Availability = true,
            Description = "Noise cancelling",
            ImageUrl = "https://via.placeholder.com/200x300?text=Buds+Pro",
            Views = 310,
            ProductManufacturer = phoneMfr,
            Section = electronics,
            Category = mobiles,
            Country = china
        };

        var airRunner = new Product
        {
            MetaTitle = "AirRunner Pro",
            Model = "AR‑2025",
            IdentificationNumber = "AR‑2025‑BLK‑42",
            Priority = 2,
            Link = "#",
            MetaTags = "sneakers, running",
            MetaDescription = "Lightweight performance shoe",
            Price = 129,
            Extra = 5,
            Profit = 45,
            Warehouse = "WH‑Tashkent",
            Amount = 300,
            Availability = true,
            Description = "Breathable mesh upper",
            ImageUrl = "https://via.placeholder.com/200x300?text=AirRunner+Pro",
            Views = 800,
            ProductManufacturer = shoeMfr,
            Section = fashion,
            Category = sneakers,
            Country = uzbek
        };

        var trailMaster = new Product
        {
            MetaTitle = "TrailMaster GTX",
            Model = "TM‑2025",
            IdentificationNumber = "TM‑2025‑GR‑42",
            Priority = 7,
            Link = "#",
            MetaTags = "trail",
            MetaDescription = "Trail running shoe",
            Price = 159,
            Extra = 7,
            Profit = 55,
            Warehouse = "WH‑Tashkent",
            Amount = 250,
            Availability = true,
            Description = "GTX membrane",
            ImageUrl = "https://via.placeholder.com/200x300?text=TrailMaster",
            Views = 380,
            ProductManufacturer = shoeMfr,
            Section = fashion,
            Category = sneakers,
            Country = uzbek
        };

        var streetLite = new Product
        {
            MetaTitle = "StreetLite Low",
            Model = "SL‑LOW‑WHT",
            IdentificationNumber = "SL‑LOW‑42",
            Priority = 8,
            Link = "#",
            MetaTags = "street",
            MetaDescription = "Casual sneaker",
            Price = 99,
            Extra = 9,
            Profit = 28,
            Warehouse = "WH‑Tashkent",
            Amount = 800,
            Availability = true,
            Description = "Everyday shoe",
            ImageUrl = "https://via.placeholder.com/200x300?text=StreetLite",
            Views = 290,
            ProductManufacturer = shoeMfr,
            Section = fashion,
            Category = sneakers,
            Country = uzbek
        };

        var proRunner = new Product
        {
            MetaTitle = "ProRunner Elite",
            Model = "PR‑ELT‑BLK",
            IdentificationNumber = "PR‑ELT‑43",
            Priority = 9,
            Link = "#",
            MetaTags = "pro, running",
            MetaDescription = "Elite running shoe",
            Price = 189,
            Extra = 5,
            Profit = 65,
            Warehouse = "WH‑Tashkent",
            Amount = 150,
            Availability = true,
            Description = "Carbon plate",
            ImageUrl = "https://via.placeholder.com/200x300?text=ProRunner",
            Views = 640,
            ProductManufacturer = shoeMfr,
            Section = fashion,
            Category = sneakers,
            Country = uzbek
        };

        var slipOn = new Product
        {
            MetaTitle = "Slip‑On Chill",
            Model = "SO‑CHILL",
            IdentificationNumber = "SO‑CH‑44",
            Priority = 10,
            Link = "#",
            MetaTags = "slip‑on",
            MetaDescription = "Easy slip‑on shoe",
            Price = 79,
            Extra = 11,
            Profit = 22,
            Warehouse = "WH‑Tashkent",
            Amount = 950,
            Availability = true,
            Description = "Canvas upper",
            ImageUrl = "https://via.placeholder.com/200x300?text=SlipOn+Chill",
            Views = 210,
            ProductManufacturer = shoeMfr,
            Section = fashion,
            Category = sneakers,
            Country = china
        };

        await db.Countries.AddRangeAsync(usa, uzbek, china);
        await db.ProductManufacturers.AddRangeAsync(phoneMfr, shoeMfr);
        await db.Sections.AddRangeAsync(electronics, fashion);
        await db.Categories.AddRangeAsync(mobiles, sneakers);
        await db.Products.AddRangeAsync(
            phonixX1, phonixA2, tabletZ, smartWatch, earbuds,
            airRunner, trailMaster, streetLite, proRunner, slipOn);

        var sales = new List<Sale>
        {
            new() { Product = phonixX1,  QuantitySold = 3,  SalePrice = 799, SaleDate = DateTime.UtcNow.AddDays(-1) },
            new() { Product = phonixX1,  QuantitySold = 2,  SalePrice = 799, SaleDate = DateTime.UtcNow.AddDays(-10) },
            new() { Product = airRunner, QuantitySold = 5,  SalePrice = 129, SaleDate = DateTime.UtcNow.AddDays(-2) },
            new() { Product = phonixA2,  QuantitySold = 6,  SalePrice = 379, SaleDate = DateTime.UtcNow.AddDays(-3) },
            new() { Product = proRunner, QuantitySold = 4,  SalePrice = 189, SaleDate = DateTime.UtcNow.AddDays(-6) },
            new() { Product = tabletZ,   QuantitySold = 1,  SalePrice = 599, SaleDate = DateTime.UtcNow.AddDays(-8) },
            new() { Product = smartWatch,QuantitySold = 10, SalePrice = 199, SaleDate = DateTime.UtcNow.AddDays(-1) }
        };

        await db.Sales.AddRangeAsync(sales);
    }
}