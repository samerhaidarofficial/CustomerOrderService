using CustomerOrderService.Business;
using CustomerOrderService.DB;
using CustomerOrderService.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CustomerOrderService.Tests
{
    public class ServiceTests
    {
        private AppDbContext NewCtx()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            return new AppDbContext(options);
        }

        [Fact]
        public  void CreateUser_ShouldMatch()
        {
            var ctx = NewCtx();
            var logger = new LoggingDataManager(ctx);
            var userDataManager = new UserDataManager(ctx);
            var userManager = new UserManager(userDataManager, logger);

            var created = userManager.Create(new CreateUserDto
            {
                Name = "Samer",
                Email = "Samer@gmail.com",
                Password = "P@ssw0rd"
            });

            var fetchedUser = userManager.Get(created.Id);
            Assert.NotNull(fetchedUser);
            Assert.Equal("Samer@gmail.com", fetchedUser!.Email);
        }

        [Fact]
        public void CreateOrder_ShouldCalculateTotal()
        {
            var ctx = NewCtx();
            var logger = new LoggingDataManager(ctx);
            var userDataManager = new UserDataManager(ctx);
            var userManager = new UserManager(userDataManager, logger);
            var createdUser = userManager.Create(new CreateUserDto { Name = "Samer1", Email = "Samer1@gmail.com", Password = "Samer1@123" });
            
            var orderDataManager = new OrderDataManager(ctx);
            var orderManager = new OrderManager(orderDataManager, logger, userDataManager);
            var orderCreated = orderManager.Create(new CreateOrderDto
            {
                UserId = createdUser.Id,
                Items =
                [
                    new CreateOrderItemDto { ProductName = "Laptop", Quantity = 1, UnitPrice = 1500 },
                    new CreateOrderItemDto { ProductName = "Mouse", Quantity = 1, UnitPrice = 30 }
                ]
            });

            Assert.Equal(1530, orderCreated.TotalPrice);
            Assert.Equal(2, orderCreated.Items.Count);
        }
    }
}
