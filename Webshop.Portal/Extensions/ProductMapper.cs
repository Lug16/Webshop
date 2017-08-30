using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webshop.Portal.Models;

namespace Webshop.Entities
{
    public static class ProductMapper
    {
        public static ProductModel Map(this Product product)
        {
            return new ProductModel
            {
                CreationDate = product.CreationDate,
                Name = product.Name,
                Number = product.Number,
                Price = product.Price,
                ProductCategoryId = product.ProductCategoryId,
                ProductCategoryName = product.ProductCategory.Name,
                ProductId = product.ProductId
            };
        }

        public static Product Map(this ProductModel model)
        {
            return new Product
            {
                CreationDate = model.CreationDate,
                Name = model.Name,
                Number = model.Number,
                Price = model.Price,
                ProductCategoryId = model.ProductCategoryId,
                ProductId = model.ProductId
            };
        }
    }
}