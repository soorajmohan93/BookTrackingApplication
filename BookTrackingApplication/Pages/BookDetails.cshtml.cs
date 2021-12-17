using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookTrackingApplication.Models;
using BookTrackingApplication.Data;
using Microsoft.EntityFrameworkCore;

namespace BookTrackingApplication.Pages
{
    public class BookDetailsModel : PageModel
    {
        private readonly BookTrackingApplicationContext _context;

        public BookDetailsModel(BookTrackingApplicationContext context)
        {
            _context = context;
        }

        [FromForm]
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
