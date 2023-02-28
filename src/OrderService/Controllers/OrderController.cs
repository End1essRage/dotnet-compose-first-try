using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Data;
using OrderService.Data.Models;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        //private IOrderRepository _orderRepository;
        private IOrderWorker _orderWorker;
        public OrderController (IOrderWorker orderWorker)
        {
            _orderWorker = orderWorker;
        }

        [HttpPut("{userOwner}")]
        public async Task<ActionResult<Order>> CreateOrder(string userOwner)
        {
            return Ok(await _orderWorker.CreateOrder(userOwner));
        }

        [HttpGet]
        public async Task<ActionResult<Order>> GetOrder(string userOwner)
        {
            return Ok(await _orderWorker.GetOrder(userOwner));
        }
    }
}
