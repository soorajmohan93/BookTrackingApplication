using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookTrackingApplication.Data;
using BookTrackingApplication.Models;

namespace BookTrackingApplication.Pages.Admin.Books
{
    public class DetailsModel : PageModel
    {
        private readonly BookTrackingApplication.Data.BookTrackingApplicationContext _context;

        public DetailsModel(BookTrackingApplication.Data.BookTrackingApplicationContext context)
        {
            _context = context;
        }

        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Books
                .Include(b => b.Categories).FirstOrDefaultAsync(m => m.ISBN == id);

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
