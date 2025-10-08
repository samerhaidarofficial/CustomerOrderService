using CustomerOrderService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderService.IDB
{
    public interface IUserDataManager
    {
        User Add(User user);
        User? Get(Guid id);
        IEnumerable<User> GetAll();
        User? Update(Guid id, User user);
    }
}
