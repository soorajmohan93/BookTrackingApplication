using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

//Model fpr Category Type
namespace BookTrackingApplication.Models
{
    public class CategoryType
    {
        [Key]
        public String Type { get; set; }

        [Required]
        [Display(Name = "Category Type Name", Description = "Name of Category Type")]
        public String Name { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
