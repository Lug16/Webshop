namespace Webshop.Kernel
{
    public interface IUnitOfWork
    {
        IProductCategoryRepository ProductCategoriesRepository { get; }
        IProductRepository ProductsRepository { get; }

        void Complete();
    }
}