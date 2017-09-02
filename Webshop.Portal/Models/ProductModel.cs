using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Webshop.Portal.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        [Display(Name = "Categories")]
        public string[] ProductCategoryNames { get; set; }

        [Display(Name = "Category Id")]
        public int[] ProductCategoryIds { get; set; }

        [Required]
        public string Number { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Display(Name = "Created at")]
        public DateTime CreationDate { get; set; }
    }
}