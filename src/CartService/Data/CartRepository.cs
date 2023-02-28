using CartService.Data.Models;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;

namespace CartService.Data
{
    public class CartRepository : ICartRepository
    {
        private string connectionString = "mongodb://mongo:27017/";
        private const string dbName = "cartDb";
        private const string collectionName = "carts";
        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(dbName);
            return db.GetCollection<T>(collection);
        }

        public async Task<Cart> CreateCart(string userName)
        {
            var cart = new Cart(userName);
            await ConnectToMongo<Cart>(collectionName).InsertOneAsync(cart);
            return cart;

        }
        public async Task<Cart> GetCartByUserAsync(string userName)
        {
            return await ConnectToMongo<Cart>(collectionName).Find(c => c.UserOwner == userName).SingleAsync();
        }

        //TODO logic layer

        public async Task AddProductToCart(string userName, Product product)
        {
            var cart = await GetCartByUserAsync(userName);
            var newPosition = new Position(product);
            if(cart.Positions == null)
            {
                cart.Positions = new List<Position>();
            }
            cart.Positions.Add(newPosition);
            await ConnectToMongo<Cart>(collectionName).ReplaceOneAsync(c => c.Id == cart.Id, cart);
            return;
        }

        public async Task ClearCart(string userName)
        {
            var cart = await GetCartByUserAsync(userName);
            cart.Positions.Clear();
            await ConnectToMongo<Cart>(collectionName).ReplaceOneAsync(c => c.Id == cart.Id, cart);
        }

        //TODO rework
        public async Task<bool> ChangeProductsAmountInCart(string userName, int productId, int amount)
        {
            var cart = await GetCartByUserAsync(userName);
            var position = cart.Positions.FirstOrDefault(p => p.Product.Id == productId);
            if (position != null && position.ChangeAmount(amount))
            {
                ConnectToMongo<Cart>(collectionName).ReplaceOneAsync(c => c.Id == cart.Id, cart);
                return true;
            }

            return false;
        }
    }
}
