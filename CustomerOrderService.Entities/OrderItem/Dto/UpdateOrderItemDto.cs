using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderService.Entities
{
    public class UpdateOrderItemDto
    {
       
        [Required, StringLength(200)] 
        public string ProductName { get; set; } = string.Empty;
        
        [Range(1, int.MaxValue)] 
        public int Quantity { get; set; }
       
        [Range(0.01, double.MaxValue)]
        public decimal UnitPrice { get; set; }
    }
}
