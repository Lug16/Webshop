using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webshop.Kernel;
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
                ProductCategoryIds = product.ProductCategories.Select(r=>r.ProductCategoryId).ToArray(),
                ProductCategoryNames = product.ProductCategories.Select(r => r.Name).ToArray(),
                ProductId = product.ProductId
            };
        }

        public static Product Map(this ProductModel model, IProductCategoryRepository repo)
        {
            return new Product
            {
                CreationDate = model.CreationDate,
                Name = model.Name,
                Number = model.Number,
                Price = model.Price,
                ProductCategories = (ICollection<ProductCategory>)repo.GetByKeys(model.ProductCategoryIds),
                ProductId = model.ProductId
            };
        }
    }
}