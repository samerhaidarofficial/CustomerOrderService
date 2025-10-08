using CustomerOrderService.Business;
using CustomerOrderService.Entities;
using CustomerOrderService.IDB;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
    
        private IUserManager _userManager;
        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public  IActionResult Create([FromBody] CreateUserDto dto)
        {
            return Ok(_userManager.Create(dto));
        }

        [HttpGet("{id:Guid}")]
        public  IActionResult Get(Guid id)
        {
            var user = _userManager.Get(id);
            return user is null ? NotFound() : Ok(user);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userManager.GetAll());
        }

        [HttpPut("{id:Guid}")]
        public  IActionResult Update(Guid id, [FromBody] UpdateUserDto dto)
        {
            var user = _userManager.Update(id, dto);
            return user is null ? NotFound() : Ok(user);
        }
    }
}
