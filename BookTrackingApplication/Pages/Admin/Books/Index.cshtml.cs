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

namespace BookTrackingApplication.Pages.Admin.Books
{
    public class IndexModel : PageModel
    {
        private readonly BookTrackingApplication.Data.BookTrackingApplicationContext _context;

        public IndexModel(BookTrackingApplication.Data.BookTrackingApplicationContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }

        public SelectList Title { get; set; }
        [BindProperty(SupportsGet = true)]
        public string BooksTitle { get; set; }

        public async Task OnGetAsync()
        {
//Logic for select tag helper
            IQueryable<string> nameQuery = from b in _context.Books
                                           orderby b.Title
                                           select b.Title;

            var books = from b in _context.Books
                           select b;

            if (!string.IsNullOrEmpty(BooksTitle))
            {
                books = books.Where(x => x.Title == BooksTitle);
            }
            Title = new SelectList(await nameQuery.Distinct().ToListAsync());
            Book = await books.Include(b => b.Categories).ToListAsync();
        }
    }
}
