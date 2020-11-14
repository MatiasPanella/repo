using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab.Capas.Models
{
    public class CategoriesView
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength (30)]
        public string CategoryName { get; set; }

        [StringLength(30)]
        public string Description { get; set; }
    }
}