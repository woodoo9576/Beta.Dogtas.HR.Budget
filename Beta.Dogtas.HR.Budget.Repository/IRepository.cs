using System.Collections.Generic;

namespace Beta.Dogtas.HR.Budget.Repository
{
    public interface IRepository<T>
    {
        void Create(T item);
        List<T> Read();
        T Read(int id);
        void Update(T item);
        void Delete(T item);
    }
}
