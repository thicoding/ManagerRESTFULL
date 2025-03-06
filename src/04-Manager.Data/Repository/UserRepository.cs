namespace _02_Manager.Data.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using _04_Manager.Data.Repository;
    using _02_Manager.Domain.Entities;
    using _04_Manager.Data.Context;
    using Microsoft.EntityFrameworkCore;

    public class UserRepository : IUserRepository
    {
        private readonly MenagerContext _context;

        public UserRepository(MenagerContext context)
        {
            _context = context;
        }

       
        public User Add(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return user;
        }

        
        public User GetId(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

       
        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        
        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        
        public void Remover(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
