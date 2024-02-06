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
        //TODO from authentication or first adding product
        public async Task<ActionResult<Cart>> CreateNewCart(string UserName)
        {   
            return Ok(await _cartRepository.CreateCart(UserName));
        }

        //TODO refactor
        [Route("{UserName}")]
        [HttpGet]
        public async Task<ActionResult<Cart>> GetCartByUser(string UserName)
        {
            var cart = await _cartRepository.GetCartByUserAsync(UserName);
            if(cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        [Route("{UserName}")]
        [HttpPatch]
        public async Task<ActionResult> AddProductToCart(string userName, Product product)
        {
            await _cartRepository.AddProductToCart(userName, product);
            return Ok();
        }

        [Route("{UserName}/clear")]
        [HttpPatch]
        public async Task<ActionResult> ClearCart(string UserName, int productId)
        {
            await _cartRepository.ClearCart(UserName);
            return Ok();
        }

        [Route("{UserName}/add/{productId}")]
        [HttpPatch]
        public async Task<ActionResult> ChangeProductsAmountInCart(string UserName, int productId, int amount)
        {
            bool isChanged = await _cartRepository.ChangeProductsAmountInCart(UserName, productId, amount);
            return isChanged ? Ok() : BadRequest();
        }
    }
}
