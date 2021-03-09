using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Models;

namespace RazorPagesProduct.Data
{
    public class RazorPagesProductContext : DbContext
    {
        public RazorPagesProductContext (DbContextOptions<RazorPagesProductContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
