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

        public String Description { get; set; }

        [ForeignKey("CategoryTypes")]
        public String Type { get; set; }

        public CategoryType CategoryTypes { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
