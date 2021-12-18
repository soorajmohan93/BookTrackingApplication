using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookTrackingApplication.Models
{
    public class Book
    {
        [Key]
        public String ISBN { get; set; }

        [Required]
        [Display(Name = "Book Title", Description = "Title of the Book")]
        public String Title { get; set; }

        [Display(Name = "Author", Description = "Author of the Book")]
        public String Author { get; set; }

        [ForeignKey("Categories"), Display(Name = "Category", Description = "Category of the Book")]
        public String Category { get; set; }

        public Category Categories { get; set; }
    }
}
