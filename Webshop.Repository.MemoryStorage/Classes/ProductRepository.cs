using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Webshop.Entities;
using Webshop.Kernel;

namespace Webshop.Repository.MemoryStorage
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> List { get; private set; }
        private TempDataDictionary _context;

        public ProductRepository(TempDataDictionary context)
        {
            this._context = context;
            if (context != null && context["Product"] != null)
            {
                List = context["Product"] as List<Product>;
            }
            else
            {
                context["Product"] = new List<Product>();
            }
        }

        public void Remove(int key)
        {
            var item = List.Where(r => r.ProductId == key).SingleOrDefault();
            if (item != null)
                List.Remove(item);
        }

        public IEnumerable<Product> GetAll()
        {
            var categories = _context["ProductCategory"] as List<ProductCategory>;
            List = _context["Product"] as List<Product>;
            List.ForEach(r => r.ProductCategory = categories.Single(i => i.ProductCategoryId == r.ProductCategoryId));
            return List;
        }

        public Product GetByKey(int? key)
        {
            if (key.HasValue)
                return List.Where(r => r.ProductId == key.Value).SingleOrDefault();

            return null;
        }

        public void Add(Product entity)
        {
            entity.ProductId = List.LastOrDefault() == null ? 1 : List.LastOrDefault().ProductId + 1;
            entity.CreationDate = DateTime.Now;
            List.Add(entity);
        }

        public Product Update(Product entity)
        {
            List.Where(r => r.ProductCategoryId == entity.ProductCategoryId).ToList()
               .ForEach(r =>
               {
                   r.Name = entity.Name;
                   r.Number = entity.Number;
                   r.Price = entity.Price;
                   r.ProductCategoryId = entity.ProductCategoryId;
               });

            return entity;
        }
    }
}