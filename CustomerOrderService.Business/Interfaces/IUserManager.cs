using CustomerOrderService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderService.Business
{
    public interface IUserManager
    {
        UserDto Create(CreateUserDto dto);
        UserDto? Get(Guid id);
        IEnumerable<UserDto> GetAll();
        UserDto? Update(Guid id, UpdateUserDto dto);
    }
}
