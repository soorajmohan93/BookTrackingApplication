using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookTrackingApplication.Models
{
    public class Category
    {
        [Key]
        public String NameToken { get; set; }

        [Required]
        [Display(Name = "Category Description", Description = "Description of Category")]
        public String Description { get; set; }

        [ForeignKey("CategoryTypes")]
        [Display(Name = "Category Type", Description = "Type of Category")]
        public String Type { get; set; }

        public CategoryType CategoryTypes { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
