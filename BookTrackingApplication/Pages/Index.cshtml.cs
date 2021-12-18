using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookTrackingApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using BookTrackingApplication.Data;
using Microsoft.EntityFrameworkCore;

namespace BookTrackingApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly BookTrackingApplicationContext Dbcontext;

        public IndexModel(ILogger<IndexModel> logger, BookTrackingApplicationContext context)
        {
            _logger = logger;
            Dbcontext = context;
        }

        public IList<CategoryType> CategoryType { get; set; }
        public IList<Category> Categories { get; set; }
        public IList<Book> Books { get; set; }

        public void OnGet()
        {
            CategoryType = Dbcontext.CategoryTypes.ToList();
            Categories = Dbcontext.Categories.ToList();
            Books = Dbcontext.Books.ToList();
        }
    }
}
