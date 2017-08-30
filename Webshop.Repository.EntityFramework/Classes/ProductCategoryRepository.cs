using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Webshop.Entities;
using Webshop.Kernel;

namespace Webshop.Repository.EntityFramework
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly Model db;

        public ProductCategoryRepository(Model context)
        {
            db = context;
        }

        public void Remove(int key)
        {
            var entity = db.ProductCategories.Find(key);
            db.ProductCategories.Remove(entity);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return db.ProductCategories.ToList();
        }

        public ProductCategory GetByKey(int? key)
        {
            return db.ProductCategories.Find(key);
        }

        public void Add(ProductCategory entity)
        {
            db.ProductCategories.Add(entity);
        }

        public ProductCategory Update(ProductCategory entity)
        {
            var item = db.ProductCategories.Find(entity.ProductCategoryId);

            item.Name = entity.Name;

            return item;
        }
    }
}