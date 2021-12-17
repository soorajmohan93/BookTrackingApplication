using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookTrackingApplication.Data;
using BookTrackingApplication.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookTrackingApplication.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private readonly BookTrackingApplication.Data.BookTrackingApplicationContext _context;

        public IndexModel(BookTrackingApplication.Data.BookTrackingApplicationContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public SelectList Description { get; set; }
        [BindProperty(SupportsGet = true)]
        public string CategoriesDesc { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> nameQuery = from d in _context.Categories
                                           orderby d.Description
                                           select d.Description;

            var category = from d in _context.Categories
                        select d;

            if (!string.IsNullOrEmpty(CategoriesDesc))
            {
                category = category.Where(x => x.Description == CategoriesDesc);
            }
            Description = new SelectList(await nameQuery.Distinct().ToListAsync());
            Category = await category.Include(c => c.CategoryTypes).ToListAsync();
        }
    }
}
