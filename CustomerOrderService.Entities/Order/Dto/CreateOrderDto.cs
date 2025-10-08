using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderService.Entities
{
    public class CreateOrderDto
    {
        [Required] 
        public Guid UserId { get; set; }
        
        [Required, MinLength(1)] 
        public List<CreateOrderItemDto> Items { get; set; } = new();
    }

}
