using LogModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Communication.Sender;
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
        private LogSender _logger;
        public OrderController (IOrderWorker orderWorker, LogSender logger)
        {
            _orderWorker = orderWorker;
            _logger = logger;
        }

        [HttpPut("{userOwner}")]
        public async Task<ActionResult<Order>> CreateOrder(string userOwner)
        {
            return Ok(await _orderWorker.CreateOrder(userOwner));
        }

        [HttpGet]
        public async Task<ActionResult<Order>> GetOrder(string userOwner)
        {
            _logger.SendMessage(new LogMessageControllers("test message"));
            return Ok(await _orderWorker.GetOrder(userOwner));
        }
    }
}
