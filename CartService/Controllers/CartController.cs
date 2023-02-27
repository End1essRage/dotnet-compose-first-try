using CartService.Data;
using CartService.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.Core.Configuration;
using MongoDB.Driver;
using System.Reflection.Metadata.Ecma335;
using MongoDB.Bson;

namespace CartService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ICartRepository _cartRepository;
        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [Route("{UserName}")]
        [HttpPut]
        public async Task<Cart> CreateNewCart(string UserName)
        {
            return await _cartRepository.CreateCart(UserName);
        }

        //ToDo refactor
        [Route("{UserName}")]
        [HttpGet]
        public async Task<Cart> GetCartByUser(string UserName)
        {
            if (await _cartRepository.GetCartByUserAsync(UserName) == null)
            {
                return await _cartRepository.CreateCart(UserName);
            }

            return await _cartRepository.GetCartByUserAsync(UserName);
        }

        [Route("{UserName}")]
        [HttpPatch]
        public async Task AddProductToCart(string userName, Product product)
        {
            await _cartRepository.AddProductToCart(userName, product);
        }

        [Route("{UserName}/clear")]
        [HttpPatch]
        public async Task ClearCart(string UserName, int productId)
        {
            await _cartRepository.ClearCart(UserName);
        }

        [Route("{UserName}/add/{productId}")]
        [HttpPatch]
        public async Task<bool> ChangeProductsAmountInCart(string UserName, int productId, int amount)
        {
            return await _cartRepository.ChangeProductsAmountInCart(UserName, productId, amount);
        }
    }
}
