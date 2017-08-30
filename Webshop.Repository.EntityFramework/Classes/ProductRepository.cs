using System;
using System.Collections.Generic;
using System.Linq;
using Webshop.Entities;
using Webshop.Kernel;

namespace Webshop.Repository.EntityFramework
{
    public class ProductRepository : IProductRepository
    {
        private Model db;

        public ProductRepository(Model context)
        {
            this.db = context;
        }

        public void Remove(int key)
        {
            db.Products.Remove(db.Products.Find(key));
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products.Include("ProductCategory").ToList();
        }

        public Product GetByKey(int? key)
        {
            return db.Products.SingleOrDefault(r => r.ProductId == key);
        }

        public void Add(Product entity)
        {
            db.Products.Add(entity);
        }

        public Product Update(Product entity)
        {
            var item = db.Products.Find(entity.ProductId);

            item.Name = entity.Name;
            item.Number = entity.Number;
            item.Price = entity.Price;

            return item;
        }
    }
}