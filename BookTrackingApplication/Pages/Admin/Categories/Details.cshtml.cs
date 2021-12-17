using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookTrackingApplication.Data;
using BookTrackingApplication.Models;

namespace BookTrackingApplication.Pages.Admin.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly BookTrackingApplication.Data.BookTrackingApplicationContext _context;

        public DetailsModel(BookTrackingApplication.Data.BookTrackingApplicationContext context)
        {
            _context = context;
        }

        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Categories
                .Include(c => c.CategoryTypes).FirstOrDefaultAsync(m => m.NameToken == id);

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
