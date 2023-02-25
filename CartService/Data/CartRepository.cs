using CartService.Data.Models;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;

namespace CartService.Data
{
    public class CartRepository : ICartRepository
    {
        private string connectionString =  Environment.GetEnvironmentVariable("MongoDbConnectionString");
        private const string dbName = "cartDb";
        private const string collectionName = "carts";
        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(dbName);
            return db.GetCollection<T>(collection);
        }
    }
}
