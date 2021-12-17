using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookTrackingApplication.Data;
using BookTrackingApplication.Models;

namespace BookTrackingApplication.Pages.Admin.Categories
{
    public class CreateModel : PageModel
    {
        private readonly BookTrackingApplication.Data.BookTrackingApplicationContext _context;

        public CreateModel(BookTrackingApplication.Data.BookTrackingApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Type"] = new SelectList(_context.CategoryTypes, "Type", "Type");
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Categories.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
