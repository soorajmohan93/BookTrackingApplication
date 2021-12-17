using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookTrackingApplication.Data;
using BookTrackingApplication.Models;

namespace BookTrackingApplication.Pages.Admin.CategoryTypes
{
    public class EditModel : PageModel
    {
        private readonly BookTrackingApplication.Data.BookTrackingApplicationContext _context;

        public EditModel(BookTrackingApplication.Data.BookTrackingApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CategoryType CategoryType { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CategoryType = await _context.CategoryTypes.FirstOrDefaultAsync(m => m.Type == id);

            if (CategoryType == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CategoryType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryTypeExists(CategoryType.Type))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CategoryTypeExists(string id)
        {
            return _context.CategoryTypes.Any(e => e.Type == id);
        }
    }
}
