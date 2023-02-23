using CatalogService.Data;
using CatalogService.Data.Models;
using CatalogService.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace CatalogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private ICategoryRepository _categoryRepository;
        private IProductRepository _productRepository;
        private ISubCategoryRepository _subCategoryRepository;
        public CatalogController(ICategoryRepository categoryRepository, IProductRepository productRepository, ISubCategoryRepository subCategoryRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _subCategoryRepository = subCategoryRepository;
        }

        //Category
        [Route("Category")]
        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            return Ok(await _categoryRepository.ListAllAsync());
        }

        [Route("Category/{categoryId}")]
        [HttpGet]
        public async Task<ActionResult<Category>> GetCategory(int categoryId)
        {
            return Ok(await _categoryRepository.GetByIdAsync(categoryId));
        }

        [Route("Category")]
        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(Category category)
        {
            return Ok(await _categoryRepository.AddAsync(category));
        }

        [Route("Category")]
        [HttpPut]
        public async Task<ActionResult> UpdateCategory(Category category)
        {
            await _categoryRepository.UpdateAsync(category);
            return NoContent();
        }

        [Route("Category/{categoryId}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteCategory(Category category)
        {
            await _categoryRepository.DeleteAsync(category);

            return NoContent();
        }

        //SubCategory
        [Route("Category/{categoryId}/SubCategory")]
        [HttpGet]
        public async Task<ActionResult<List<SubCategory>>> GetAllSubCategories(int categoryId)
        {
            return Ok(await _subCategoryRepository.GetSubCategoriesAsync(categoryId));//TODO by category
        }

        [Route("Category/{categoryId}/SubCategory/{subCategoryId}")]
        [HttpGet]
        public async Task<ActionResult<SubCategory>> GetSubCategory(int categoryId, int subCategoryId)
        {
            return Ok(await _subCategoryRepository.GetByIdAsync(subCategoryId));
        }

        [Route("Category/{categoryId}/SubCategory")]
        [HttpPost]
        public async Task<ActionResult<SubCategory>> CreateSubCategory(int categoryId, SubCategory subCategory)
        {
            return Ok(await _subCategoryRepository.AddSubCategoryAsync(categoryId, subCategory));
        }

        [Route("Category/{categoryId}/SubCategory")]
        [HttpPut]
        public async Task<ActionResult> UpdateSubCategory(int categoryId, SubCategory subCategory)
        {
            await _subCategoryRepository.UpdateAsync(subCategory);

            return NoContent();
        }

        //[Route("Category/{categoryId}/SubCategory/{subCategoryId}")]
        //[HttpPatch]
        //public IActionResult PatchSubCategory(int categoryId, int subCategoryId, SubCategory subCategory)//TODO Key-value
        //{
        //    return NoContent();
        //}

        [Route("Category/{categoryId}/SubCategory/{subCategoryId}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteSubCategory(int categoryId, SubCategory subCategory)
        {
            await _subCategoryRepository.DeleteAsync(subCategory);
            return NoContent();
        }

        //Product
        [Route("Category/{categoryId}/SubCategory/{subCategoryId}/Product")]
        [HttpGet]
        public async Task<ActionResult<Product>> GetAllProducts(int categoryId, int subCategoryId)
        {
            return Ok(await _productRepository.GetProductsAsync(subCategoryId));
        }

        [Route("Category/{categoryId}/SubCategory/{subCategoryId}/Product/{productId}")]
        [HttpGet]
        public async Task<ActionResult<Product>> GetProduct(int categoryId, int subCategoryId, int productId)
        {
            return Ok(await _productRepository.GetByIdAsync(productId));
        }

        [Route("Category/{categoryId}/SubCategory/{subCategoryId}/Product")]
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(int categoryId, int subCategoryId, Product product)
        {
            return Ok(await _productRepository.AddProductAsync(subCategoryId, product));
        }

        [Route("Category/{categoryId}/SubCategory/{subCategoryId}/Product/{productId}")]
        [HttpPut]
        public async Task<ActionResult> UpdateProduct(int categoryId, int subCategoryId, int productId, Product product)
        {
            await _productRepository.UpdateAsync(product);

            return NoContent();
        }

        //[Route("Category/{categoryId}/SubCategory/{subCategoryId}/Product/{productId}")]
        //[HttpPatch]
        //public IActionResult PatchProduct(int categoryId, int subCategoryId, int productId, Product product)//TODO Key-value
        //{
        //    return NoContent();
        //}

        [Route("Category/{categoryId}/SubCategory/{subCategoryId}/Product/{productId}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteProduct(int categoryId, int subCategoryId, Product product)
        {
            await _productRepository.DeleteAsync(product);

            return NoContent();
        }

    }
}
