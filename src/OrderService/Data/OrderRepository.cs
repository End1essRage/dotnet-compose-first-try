using MongoDB.Bson;
using MongoDB.Driver;
using OrderService.Data.Models;

namespace OrderService.Data
{
    public class OrderRepository : IOrderRepository
    {
        private string connectionString = "mongodb://mongo:27017/";
        private const string dbName = "orderDb";
        private const string collectionName = "orders";
        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(dbName);
            return db.GetCollection<T>(collection);
        }
        public async Task<Order> GetOrderByUser(string userName)
        {
            return await ConnectToMongo<Order>(collectionName).Find(c => c.UserOwner == userName).SingleAsync();
        }

        public async Task<Order> CreateNewOrder(string userOwner, List<Position> positions)
        {
            int lastOrderNumber = 0;
            if (ConnectToMongo<Order>(collectionName).Count(o => o.Id != null) > 0)
            {
                lastOrderNumber = await ConnectToMongo<Order>(collectionName).Find(new BsonDocument()).Project(c => c.OrderNumber).SortByDescending(c => c.OrderNumber).FirstAsync();
            }
            
            var order = new Order(userOwner, ++lastOrderNumber,  positions);
            await ConnectToMongo<Order>(collectionName).InsertOneAsync(order);
            return order;
        }

        public async Task<Order> SaveChanges(Order order)
        {
            await ConnectToMongo<Order>(collectionName).ReplaceOneAsync(o => o.Id == order.Id, order);
            return order;
        }
    }
}
