using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderDbContext dbContext;
       // private readonly ILogger logger;

        public OrdersController(OrderDbContext dbContext)
        {
            this.dbContext = dbContext;
            //this.logger = logger;
        }

        [HttpGet]
        public List<Order> Get()
        {
            return this.dbContext.Orders.ToList() ?? new List<Order>();
        }

        [HttpPost]
        public string Post(Order order)
        {
            if (order is null)
            {
               // this.logger.LogError("Order object sent by client is null");
            }
            this.dbContext.Orders.Add(order);
            this.dbContext.SaveChanges();
            return this.dbContext.Orders.SingleOrDefault(order => order.Id == order.Id).Id.ToString() ?? "";
        }

        [HttpDelete]
        public string Delete(Guid orderId)
        {
            this.dbContext.Orders.Where(order => order.Id == orderId).ExecuteDelete();
            this.dbContext.SaveChanges();
            return "Success";
        }
    }
}
