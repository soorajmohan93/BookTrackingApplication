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

namespace BookTrackingApplication.Pages.Admin.CategoryTypes
{
    public class IndexModel : PageModel
    {
        private readonly BookTrackingApplication.Data.BookTrackingApplicationContext _context;

        public IndexModel(BookTrackingApplication.Data.BookTrackingApplicationContext context)
        {
            _context = context;
        }

        public IList<CategoryType> CategoryType { get;set; }

        public SelectList Names { get; set; }
        [BindProperty(SupportsGet = true)]
        public string CategoriesNames { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> nameQuery = from c in _context.CategoryTypes
                                            orderby c.Name
                                            select c.Name;

            var types = from c in _context.CategoryTypes
                         select c;

            if (!string.IsNullOrEmpty(CategoriesNames))
            {
                types = types.Where(x => x.Name == CategoriesNames);
            }
            Names = new SelectList(await nameQuery.Distinct().ToListAsync());
            CategoryType = await types.ToListAsync();
        }
    }
}
