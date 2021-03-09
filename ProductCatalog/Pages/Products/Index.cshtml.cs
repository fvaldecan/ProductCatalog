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
using System.Diagnostics;
namespace ProductCatalog.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesProduct.Data.RazorPagesProductContext _context;

        public IndexModel(RazorPagesProduct.Data.RazorPagesProductContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get; set; }
        public IList<ProductView> ProductView { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FilterString { get; set; }

        public SelectList Categories { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ProductCategory { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> categoryQuery = from c in _context.Category
                                               orderby c.Name
                                               select c.Name;

            //from p in _context.Product
            //orderby p.CategoryId
            //select p.CategoryId;
            var products = from m in _context.Product
                         select m;
            var productViews = (from p in _context.Product
                                join c in _context.Category on p.CategoryId equals c.ID
                                select new ProductView
                                {
                                    ID = p.ID,
                                    Name = p.Name,
                                    Category = c.Name,
                                    Price = p.Price
                                });
            //Debug.Write(products);
            Debug.Write(productViews);
            if (!string.IsNullOrEmpty(ProductCategory))
            {
                Debug.WriteLine(ProductCategory);
                if (ProductCategory != "All" || ProductCategory != "")
                {

                    productViews = productViews.Where(p => p.Category == ProductCategory);
                }
            }
            //if (!string.IsNullOrEmpty(ProductCategory))
            //{
            //    products = products.Where(s => s.CategoryId == ProductCategory);
            //}
            Categories = new SelectList(await categoryQuery.Distinct().ToListAsync());
            ProductView = await productViews.ToListAsync();
        }
    }
}
