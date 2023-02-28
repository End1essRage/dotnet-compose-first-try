using OrderService.Data.Models;

namespace OrderService.Data
{
    public interface IOrderWorker
    {
        public Task<Order> CreateOrder(string userOwner);
        public Task<Order> GetOrder(string userOwner);
    }
}
