using Webshop.Kernel;

namespace Webshop.Repository.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Model _context;

        public IProductCategoryRepository ProductCategoriesRepository { get; private set; }

        public IProductRepository ProductsRepository { get; private set; }

        public UnitOfWork(Model context)
        {
            _context = context;
            ProductCategoriesRepository = new ProductCategoryRepository(context);
            ProductsRepository = new ProductRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}