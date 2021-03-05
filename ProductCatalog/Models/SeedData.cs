using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesProduct.Data;

namespace ProductCatalog.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesProductContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesProductContext>>()))
            {
                if (context.Product.Any()) { return; }
                context.Product.AddRange(
                    new Product
                    {
                        Name = "Kicks I",
                        Category = "Shoes",
                        Price = 199.99M
                    },
                    new Product
                    {
                        Name = "Kicks II",
                        Category = "Shoes",
                        Price = 299.99M
                    },
                    new Product
                    {
                        Name = "Sneaker I",
                        Category = "Shoes",
                        Price = 199.99M
                    },
                    new Product
                    {
                        Name = "Baseball Tee",
                        Category = "Shirts",
                        Price = 10.99M
                    },
                    new Product
                    {
                        Name = "Plain White Tee",
                        Category = "Shirts",
                        Price = 5.99M
                    }

                );
                context.SaveChanges();
                    
            }
        }
    }
}
