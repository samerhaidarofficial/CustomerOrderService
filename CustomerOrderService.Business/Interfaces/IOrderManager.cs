using CustomerOrderService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderService.Business
{
    public interface IOrderManager
    {
        OrderDto Create(CreateOrderDto dto);
        OrderDto? Get(Guid id);
        IEnumerable<OrderDto> GetAll();
        OrderDto? Update(Guid id, UpdateOrderDto dto);
        OrderDto? AddItem(Guid orderId, CreateOrderItemDto dto);
        OrderDto? UpdateItem(Guid orderId, Guid itemId, UpdateOrderItemDto dto);
        IEnumerable<OrderItemDto>? GetItems(Guid orderId);
    }
}
