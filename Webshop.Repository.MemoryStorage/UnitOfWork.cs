using System.Web.Mvc;
using Webshop.Kernel;

namespace Webshop.Repository.MemoryStorage
{
    public class UnitOfWork : IUnitOfWork
    {
        public IProductCategoryRepository ProductCategoriesRepository { get; private set; }

        public IProductRepository ProductsRepository { get; private set; }

        public UnitOfWork(TempDataDictionary context)
        {
            ProductCategoriesRepository = new ProductCategoryRepository(context);
            ProductsRepository = new ProductRepository(context);
        }

        public void Complete()
        {
            //_context.SaveChanges();
        }
    }
}