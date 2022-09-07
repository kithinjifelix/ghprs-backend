using System.Collections.Generic;
using GHPRS.Core.Entities;

namespace GHPRS.Core.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
