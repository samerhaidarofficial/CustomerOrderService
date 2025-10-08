using CustomerOrderService.Entities;
using CustomerOrderService.IDB;

namespace CustomerOrderService.Business
{
    public class OrderManager: IOrderManager
    {
        private readonly IOrderDataManager _orderDataManager;
        private readonly ILoggingDataManager _loggingDataManager;
        private readonly IUserDataManager _userDataManager;

        public OrderManager(IOrderDataManager orderDataManager, ILoggingDataManager loggingDataManager, IUserDataManager userDataManager) 
        { 
            _orderDataManager = orderDataManager;
            _loggingDataManager = loggingDataManager;
            _userDataManager = userDataManager; 
        }

        public OrderDto Create(CreateOrderDto dto)
        {

            var userExists = _userDataManager.Get(dto.UserId);
            if (userExists == null)
                throw new InvalidOperationException($"User {dto.UserId} does not exist.");

            var orderToAdd = new Order
            {
                UserId = dto.UserId,
                Items = dto.Items.Select(i => new OrderItem
                {
                    ProductName = i.ProductName,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice
                }).ToList()
            };

            orderToAdd.TotalPrice = orderToAdd.Items.Sum(i => i.Subtotal);

            var result = _orderDataManager.Add(orderToAdd);
            _loggingDataManager.LogAudit("CREATE", "Order", $"OrderId={result.Id}");

            var order = _orderDataManager.Get(result.Id) ?? throw new Exception("Failed to create order");
            return order == null ? throw new Exception("Failed to create order"): Map(order) ;
        }

        public OrderDto? Get(Guid id)
        {
            var order = _orderDataManager.Get(id);
            return order is null ? null : Map(order);
        }

        public IEnumerable<OrderDto> GetAll()
        {
            return _orderDataManager.GetAll().Select(Map);
        }

        public OrderDto? Update(Guid id, UpdateOrderDto dto)
        {

            var orderToUpdate = _orderDataManager.Get(id);
            if (orderToUpdate is null) 
                return null;

            orderToUpdate.Items = dto.Items.Select(i => new OrderItem
            {
                OrderId = orderToUpdate.Id,
                ProductName = i.ProductName,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice
            }).ToList();

            orderToUpdate.TotalPrice = orderToUpdate.Items.Sum(i => i.Subtotal);
            orderToUpdate.UserId = dto.UserId; 
            
            var result =  _orderDataManager.Update(orderToUpdate);
            
            _loggingDataManager.LogAudit("UPDATE", "Order", $"OrderId={orderToUpdate.Id}");

            var order = _orderDataManager.Get(result.Id) ?? throw new Exception("Failed to create order");
            return order == null ? throw new Exception("Failed to create order") : Map(order);
        }

        public OrderDto? AddItem(Guid orderId, CreateOrderItemDto dto)
        {
            var orderToUpdate = _orderDataManager.Get(orderId);
            if (orderToUpdate is null)
                return null;

            var item = new OrderItem
            {
                OrderId = orderId,
                ProductName = dto.ProductName,
                Quantity = dto.Quantity,
                UnitPrice = dto.UnitPrice
            };

            orderToUpdate.Items.Add(item);

            orderToUpdate.TotalPrice = orderToUpdate.Items.Sum(i => i.Subtotal);

            var order = _orderDataManager.AddItem(orderToUpdate);
            _loggingDataManager.LogAudit("CREATE", "OrderItem", $"OrderId={order.Id}; ItemId={item.Id}");

            return Map(order);
        }

        public OrderDto? UpdateItem(Guid orderId, Guid itemId, UpdateOrderItemDto dto)
        {
            var orderToUpdate = _orderDataManager.Get(orderId);
            if (orderToUpdate is null)
                return null;

            var item = orderToUpdate.Items.FirstOrDefault(i => i.Id == itemId);
            if (item is null)
                return null;

            item.ProductName = dto.ProductName;
            item.Quantity = dto.Quantity;
            item.UnitPrice = dto.UnitPrice;
            orderToUpdate.TotalPrice = orderToUpdate.Items.Sum(i => i.Subtotal);

            var order = _orderDataManager.UpdateItem(orderToUpdate); ;
            _loggingDataManager.LogAudit("UPDATE", "OrderItem", $"OrderId={order.Id}; ItemId={item.Id}");

            return Map(order);
        }

        public IEnumerable<OrderItemDto>? GetItems(Guid orderId)
        {
            var orderItems = _orderDataManager.GetItems(orderId);
            if (orderItems == null)
                return null;
            
            return orderItems.Select(MapItem).ToList();
        }


        private OrderDto Map(Order order)
        {
            var orderDto = new OrderDto
            {
                Id = order.Id,
                Items = new List<OrderItemDto>(),
                TotalPrice = order.TotalPrice,
                UserId = order.UserId
            };
            if (order.Items != null)
            {
                foreach (var item in order.Items)
                {
                    orderDto.Items.Add(MapItem(item));
                }
            }

            return orderDto;
        }
        private OrderItemDto MapItem(OrderItem orderItem)
        {
            return new OrderItemDto
            {
                Id = orderItem.Id,
                Subtotal = orderItem.Subtotal,
                OrderId = orderItem.OrderId,
                ProductName = orderItem.ProductName,
                Quantity = orderItem.Quantity,
                UnitPrice = orderItem.UnitPrice,
            };
        }
    }
}
