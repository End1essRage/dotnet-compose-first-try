using OrderService.Data.Models;

namespace OrderService.Data
{
    public interface IOrderRepository
    {
        public Task<Order> CreateNewOrder(string userOwner, List<Position> positions);
        public Task<Order> SaveChanges(Order order);
        public Task<Order> GetOrderByUser(string userName);
    }
}
