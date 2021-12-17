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
        public String Title { get; set; }

        public String Author { get; set; }

        [ForeignKey("Categories")]
        public String Category { get; set; }

        public Category Categories { get; set; }
    }
}
