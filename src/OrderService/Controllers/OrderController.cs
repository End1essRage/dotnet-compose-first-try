using LogModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Communication.Sender;
using OrderService.Data.Models;
using OrderService.Logic;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        //private IOrderRepository _orderRepository;
        private IOrderWorker _orderWorker;
        private ILogSender _logger;
        public OrderController (IOrderWorker orderWorker, ILogSender logger)
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
            _logger.SendMessage(new LogMessage("test message 1", LogMessageTag.runtime));
            return Ok(await _orderWorker.GetOrder(userOwner));
        }
    }
}
