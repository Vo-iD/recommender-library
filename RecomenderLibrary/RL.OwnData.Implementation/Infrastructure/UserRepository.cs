using System;
using System.Data.Entity;
using System.Linq;
using RL.Entity.Own;
using RL.OwnData.Contract.Infrastructure;

namespace RL.OwnData.Implementation.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly BookContext _context;
        private readonly IDbSet<User> _entities;

        public UserRepository(BookContext context)
        {
            _context = context;
            _entities = context.Set<User>();
        }

        public void Update(User data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            if (_entities.FirstOrDefault(e => e.Id == data.Id) == null)
            {
                throw new ArgumentException("Entity with this id does not exist");
            }

            _context.Entry(data).State = EntityState.Modified;
        }

        public User GetUser(string id)
        {
            _context.Configuration.LazyLoadingEnabled = true;
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
