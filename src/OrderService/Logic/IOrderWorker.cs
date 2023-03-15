using OrderService.Data.Models;

namespace OrderService.Logic
{
    public interface IOrderWorker
    {
        public Task<Order> CreateOrder(string userOwner);
        public Task<Order> GetOrder(string userOwner);
        public Task ChangeOrderStatus(int orderNumber, string status);
    }
}
