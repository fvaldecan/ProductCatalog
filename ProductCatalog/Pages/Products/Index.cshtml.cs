using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Models;
using RazorPagesProduct.Data;

namespace ProductCatalog.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesProduct.Data.RazorPagesProductContext _context;

        public IndexModel(RazorPagesProduct.Data.RazorPagesProductContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }


        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Categories { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ProductCategory { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string> categoryQuery = from p in _context.Product
                                               orderby p.Category
                                               select p.Category;

            var products = from p in _context.Product
                           select p;
            if (!string.IsNullOrEmpty(SearchString))
            {
                products = products.Where(s => s.Name.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(ProductCategory))
            {
                products = products.Where(s => s.Category == ProductCategory);
            }
            Categories = new SelectList(await categoryQuery.Distinct().ToListAsync());
            Product = await products.ToListAsync();
        }
    }
}
