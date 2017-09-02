    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Webshop.Entities;
using Webshop.Kernel;

namespace Webshop.Repository.MemoryStorage
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        public List<ProductCategory> List { get; private set; }
        private TempDataDictionary _context;

        public ProductCategoryRepository(TempDataDictionary context)
        {
            this._context = context;
            if (context != null && context["ProductCategory"] != null)
            {
                List = context["ProductCategory"] as List<ProductCategory>;
            }
            else
            {
                context["ProductCategory"] = new List<ProductCategory>();
            }
        }

        public void Remove(int key)
        {
            var item = List.Where(r => r.ProductCategoryId == key).SingleOrDefault();
            if (item != null)
                List.Remove(item);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            List = _context["ProductCategory"] as List<ProductCategory>;

            return List;
        }

        public ProductCategory GetByKey(int? key)
        {
            if (key.HasValue)
                return List.Where(r => r.ProductCategoryId == key.Value).SingleOrDefault();

            return null;
        }

        public void Add(ProductCategory entity)
        {
            entity.ProductCategoryId = List.LastOrDefault() == null ? 1 : List.LastOrDefault().ProductCategoryId + 1;
            entity.CreationDate = DateTime.Now;
            List.Add(entity);
        }

        public ProductCategory Update(ProductCategory entity)
        {
            List.Where(r => r.ProductCategoryId == entity.ProductCategoryId).ToList()
                .ForEach(r => r.Name = entity.Name);

            return entity;
        }

        public IEnumerable<ProductCategory> GetByKeys(int[] keys)
        {
            return List.Where(r => keys.Contains(r.ProductCategoryId)).ToArray();
        }
    }
}