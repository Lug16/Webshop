using System.Collections.Generic;

namespace Webshop.Kernel
{
    public interface IStorable<T>
    {
        IEnumerable<T> GetAll();

        T GetByKey(int? key);

        void Add(T entity);

        T Update(T entity);

        void Remove(int key);
    }
}