using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GHPRS.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly GhprsContext Context;
        private readonly IQueryable<User> _entities;
        private readonly DbSet<User> _users;
        public UserRepository(GhprsContext context)
        {
            this.Context = context;
            _entities = context.Users
                 .Include(i => i.Person)
                 .AsNoTracking();
            _users = context.Set<User>();
        }
        public IEnumerable<User> GetAll()
        {
            return _entities.AsEnumerable();
        }
        public User GetById(string id)
        {
            return _entities.SingleOrDefault(s => s.Id == id);
        }

        public User GetByUserName(string username)
        {
            return _entities.SingleOrDefault(s => s.UserName == username);
        }

        public User Insert(User entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _users.Add(entity);
            Context.SaveChanges();
            return entity;
        }
        public void Update(User entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            Context.SaveChanges();
        }
        public void Delete(string id)
        {
            if (id == "") throw new ArgumentNullException("entity");

            User entity = _entities.SingleOrDefault(s => s.Id == id);
            _users.Remove(entity);
            Context.SaveChanges();
        }
    }
}
