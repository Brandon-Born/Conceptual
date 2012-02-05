using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain.Entities;
using Infrastructure;

namespace DatabaseInitialization
{
    internal class DatabaseInitilizer : DropCreateDatabaseAlways<DomainContext>
    {
        protected override void Seed(DomainContext context)
        {
            var categories = new List<Category>()
            {
                new Category { Name = "Books" },
                new Category { Name = "Hardware" },
                new Category { Name = "Software" },
                new Category { Name = "TVs" },
                new Category { Name = "Peripherals" }
            };

            new List<Product>()
            {
                new Product { Category = categories.Single(c => c.Name == "Software"), Name = "Microsoft Office 2010", Price = new Price() { RetailPrice = 150.00M, WholesalePrice = 84.99M }},
                new Product { Category = categories.Single(c => c.Name == "Software"), Name = "Visual Studio 2008", Price = new Price() { RetailPrice = 250.45M, WholesalePrice = 140.23M }},
                new Product { Category = categories.Single(c => c.Name == "Software"), Name = "Sql Server 2005", Price = new Price() { RetailPrice = 1500.55M, WholesalePrice = 854.55M }},
                new Product { Category = categories.Single(c => c.Name == "Hardware"), Name = "Dell Computer XPS332", Price = new Price() { RetailPrice = 1355.78M, WholesalePrice = 955.54M }},
                new Product { Category = categories.Single(c => c.Name == "TVs"), Name = "Samsung Plasma", Price = new Price() { RetailPrice = 2546.58M, WholesalePrice = 1577.45M}},

            }.ForEach(p => context.Products.Add(p));
        }
    }
}
