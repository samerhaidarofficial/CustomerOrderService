using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CustomerOrderService.Entities
{
    public class OrderItemDto
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        public Order Order { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }
    }
}
