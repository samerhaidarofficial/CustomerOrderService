using CustomerOrderService.Entities;
using CustomerOrderService.IDB;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrderService.DB
{
    public class OrderDataManager : IOrderDataManager
    {
        private readonly AppDbContext _context;
        public OrderDataManager(AppDbContext context)
        {
            _context = context;
        }

        public Order Add(Order orderToAdd)
        {
            _context.Orders.Add(orderToAdd);
            _context.SaveChanges();
            return orderToAdd;
        }

        public Order? Update(Order orderToUpdate)
        {
            _context.OrderItems.RemoveRange(orderToUpdate.Items);
            _context.Update(orderToUpdate);
            _context.SaveChanges();
            return orderToUpdate;
        }

        public Order? Get(Guid id)
        {
            return _context.Orders.Include(o => o.Items).FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.Include(o => o.Items);
        } 

        public Order? AddItem(Order orderToUpdate) //Implemented like this as separate method for future change and in case of order and order item database relation so the add or update done only on specific row and table 
        {
            _context.Update(orderToUpdate);
            _context.SaveChanges();
            return orderToUpdate;
        }

        public Order? UpdateItem(Order orderToUpdate)//Implemented like this as separate method for future change and in case of order and order item database relation so the add or update done only on specific row and table 
        {
            _context.Update(orderToUpdate);  
            _context.SaveChanges();
            return orderToUpdate;
        }

        public  List<OrderItem>? GetItems(Guid orderId)
        {
            var order = Get(orderId);
            if (order is null) 
                return null;

            return order is null ? null : order.Items.ToList();
        }

  
    }
}
