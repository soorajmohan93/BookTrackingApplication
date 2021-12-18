using System;
using Microsoft.EntityFrameworkCore;
using BookTrackingApplication.Models;

//Database Context Class for Book Tracking
namespace BookTrackingApplication.Data
{
    public class BookTrackingApplicationContext : DbContext
    {
        public BookTrackingApplicationContext(DbContextOptions<BookTrackingApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CategoryType> CategoryTypes { get; set; }

    }
}
