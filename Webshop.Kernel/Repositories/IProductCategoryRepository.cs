using System.Collections;
using System.Collections.Generic;
using Webshop.Entities;

namespace Webshop.Kernel
{
    public interface IProductCategoryRepository : IStorable<ProductCategory>
    {
        IEnumerable<ProductCategory> GetByKeys(int[] keys);
    }
}