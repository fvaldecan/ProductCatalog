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
    public class CreateModel : PageModel
    {
        private readonly RazorPagesProduct.Data.RazorPagesProductContext _context;

        public CreateModel(RazorPagesProduct.Data.RazorPagesProductContext context)
        {
            _context = context;
        }

        
        [BindProperty]
        public Product Product { get; set; }
        public SelectList Categories { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ProductCategory { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            
            IQueryable<string> categoryQuery = from c in _context.Category
                                               orderby c.Name
                                               select c.Name;
            Categories = new SelectList(await categoryQuery.Distinct().ToListAsync());
            return Page();

        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }
            int categoryId = (from c in _context.Category
                              where c.Name == ProductCategory
                                   select c.ID).ToList()[0];
            Product.CategoryId = categoryId;
            _context.Product.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }


    }
}
