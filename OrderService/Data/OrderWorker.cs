using OrderService.Data.Models;

namespace OrderService.Data
{
    public class OrderWorker : IOrderWorker
    {
        private IOrderRepository _repository;
        public OrderWorker(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Order> CreateOrder(string userOwner)
        {
            //send grpc request to get list of products
            Product firstTestProduct = new Product(1, "firstTestProduct", 123.00);
            Product secondTestProduct = new Product(2, "secondTestProduct", 321.00);
            List<Position> Positions = new List<Position>()
            {
                new Position(firstTestProduct, 3),
                new Position(secondTestProduct, 2)
            };
            //send message to catalog service
            return await _repository.CreateNewOrder(userOwner, Positions);
        }

        public async Task<Order> GetOrder(string userOwner)
        {
            return await _repository.GetOrderByUser(userOwner);
        }
    }
}
