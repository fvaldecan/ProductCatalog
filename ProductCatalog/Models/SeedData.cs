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
                if (context.Product.Any() && context.Category.Any()) { return; }
                else if (!context.Product.Any())
                {
                    context.Product.AddRange(
                        new Product
                        {
                            Name = "Kicks I",
                            CategoryId = 1,
                            Price = 199.99M
                        },
                        new Product
                        {
                            Name = "Kicks II",
                            CategoryId = 1,
                            Price = 299.99M
                        },
                        new Product
                        {
                            Name = "Sneaker I",
                            CategoryId = 1,
                            Price = 199.99M
                        },
                        new Product
                        {
                            Name = "Baseball Tee",
                            CategoryId = 2,
                            Price = 10.99M
                        },
                        new Product
                        {
                            Name = "Plain White Tee",
                            CategoryId = 2,
                            Price = 5.99M
                        },
                        new Product
                        {
                            Name = "Cut Pants",
                            CategoryId = 3,
                            Price = 5.99M
                        }

                    );
                }
                else if (!context.Category.Any())
                {
                    context.Category.AddRange(
                        new Category
                        {
                            Name = "Shoes"
                        },
                        new Category
                        {
                            Name = "Shirts"
                        },
                        new Category
                        {
                            Name = "Shorts"
                        }
                    );
                
                        
                }
                context.SaveChanges();
                    
            }
        }
    }
}
