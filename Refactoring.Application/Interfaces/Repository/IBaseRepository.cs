using System.Collections.Generic;

namespace Refactoring.Application.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T model);

        void Update(T model);

        void Delete(T model);

        IEnumerable<T> GetAll();
    }
}