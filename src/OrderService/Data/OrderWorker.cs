using OrderService.Communication.Sender;
using OrderService.Data.Models;

namespace OrderService.Data
{
    public class OrderWorker : IOrderWorker
    {
        private IOrderRepository _repository;
        private IOrderSender _sender;
        public OrderWorker(IOrderRepository repository, IOrderSender sender)
        {
            _repository = repository;
            _sender = sender;
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

            List<Tuple<int, int>> message = new List<Tuple<int, int>>();
            foreach(var position in Positions)
            {
                message.Add(new Tuple<int, int>(position.Product.Id, position.Amount));
            }

            //send message to catalog service
            _sender.SendOrderPositionsInfo(message);

            return await _repository.CreateNewOrder(userOwner, Positions);
        }

        public async Task<Order> GetOrder(string userOwner)
        {
            return await _repository.GetOrderByUser(userOwner);
        }
    }
}
