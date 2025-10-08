using CustomerOrderService.Entities;
using CustomerOrderService.IDB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderService.DB
{
    public class UserDataManager : IUserDataManager
    {
        private readonly AppDbContext _context;
        public UserDataManager(AppDbContext context)
        {
            _context = context;
        }

        public  User Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User? Get(Guid id)
        {
            return _context.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User? Update(Guid id, User user)
        {
            _context.Update(user);
            _context.SaveChanges();
            return user;
        }

    }
}
