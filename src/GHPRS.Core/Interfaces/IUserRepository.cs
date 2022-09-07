using System.Collections.Generic;
using GHPRS.Core.Entities;

namespace GHPRS.Core.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(string id);
        User GetByUserName(string username);
        User Insert(User entity);
        void Update(User entity);
        void Delete(string id);
    }
}
