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

        [Display(Name = "Category")]
        public string ProductCategoryName { get; set; }

        [Required]
        [Display(Name = "Category Id")]
        public int ProductCategoryId { get; set; }

        [Required]
        public string Number { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }

        public DateTime CreationDate { get; set; }
    }
}