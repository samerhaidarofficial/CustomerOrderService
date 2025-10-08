using CustomerOrderService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderService.IDB
{
    public interface IOrderDataManager
    {
        Order Add(Order orderToAdd);
        Order? Get(Guid id);
        IEnumerable<Order> GetAll();
        Order? Update(Order orderToUpdate);
        Order? AddItem(Order orderToUpdate);
        Order? UpdateItem(Order orderToUpdate);
        List<OrderItem>? GetItems(Guid orderId);
    }
}
