using CustomerOrderService.Business;
using CustomerOrderService.Entities;
using CustomerOrderService.IDB;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrderService.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private IOrderManager _orderManager;
        public OrderController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        [HttpPost]
        public  IActionResult Create([FromBody] CreateOrderDto dto)
        {
            return Ok(_orderManager.Create(dto));
        }

        [HttpGet("{id:Guid}")]
        public  IActionResult Get(Guid id)
        {
            var order = _orderManager.Get(id);
            return order is null ? NotFound() : Ok(order);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
           return Ok(_orderManager.GetAll());
        }

        [HttpPut("{id:Guid}")]
        public  IActionResult Update(Guid id, [FromBody] UpdateOrderDto dto)
        {
            var order = _orderManager.Update(id, dto);
            return order is null ? NotFound() : Ok(order);
        }

        [HttpPost("{orderId:Guid}/items")]
        public  IActionResult AddItem(Guid orderId, [FromBody] CreateOrderItemDto dto)
        {
            var order = _orderManager.AddItem(orderId, dto);
            return order is null ? NotFound() : Ok(order);
        }

        [HttpPut("{orderId:Guid}/items/{itemId:Guid}")]
        public  IActionResult UpdateItem(Guid orderId, Guid itemId, [FromBody] UpdateOrderItemDto dto)
        {
            var order = _orderManager.UpdateItem(orderId, itemId, dto);
            return order is null ? NotFound() : Ok(order);
        }

        [HttpGet("{orderId:Guid}/items")]
        public  IActionResult GetItems(Guid orderId)
        {
            var items = _orderManager.GetItems(orderId);
            return items is null ? NotFound() : Ok(items);
        }
    }
}
