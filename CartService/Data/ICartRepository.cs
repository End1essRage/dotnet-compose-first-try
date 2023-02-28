using CartService.Data.Models;

namespace CartService.Data
{
    public interface ICartRepository
    {
        public Task<Cart> CreateCart(string userName);
        public Task<Cart> GetCartByUserAsync(string userName);
        public Task AddProductToCart(string userName, Product product);
        public Task ClearCart(string userName);
        public Task<bool> ChangeProductsAmountInCart(string userName, int productId, int amount);
    }
}
