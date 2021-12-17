using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookTrackingApplication.Models
{
    public class CategoryType
    {
        [Key]
        public String Type { get; set; }

        public String Name { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
