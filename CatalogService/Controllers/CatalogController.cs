using CatalogService.Data;
using CatalogService.Data.Models;
using CatalogService.Data.Repositories;
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
        public CatalogController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        //Category
        [Route("Category")]
        [HttpGet]
        public ActionResult<List<Category>> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }

        [Route("Category/{categoryId}")]
        [HttpGet]
        public IActionResult GetCategory(int categoryId)
        {
            return NoContent();
        }

        [Route("Category")]
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            var categoryCreated = _categoryRepository.AddCategory(category);
            return CreatedAtAction(nameof(CreateCategory), new { Id = categoryCreated.Id }, categoryCreated);
        }

        [Route("Category")]
        [HttpPut]
        public IActionResult UpdateCategory( Category category)
        {
            _categoryRepository.UpdateCategory(category);
            return NoContent();
        }

        //[Route("Category/{categoryId}")]
        //[HttpPatch]
        //public IActionResult PatchCategory(int categoryId, Category category)//TODO Key-value
        //{
        //    return NoContent();
        //}

        [Route("Category/{categoryId}")]
        [HttpDelete]
        public IActionResult DeleteCategory(int categoryId)
        {
            _categoryRepository.DeleteCategory(categoryId);

            return NoContent();
        }

        //SubCategory
        [Route("Category/{categoryId}/SubCategory")]
        [HttpGet]
        public IActionResult GetAllSubCategories(int categoryId)
        {
            return NoContent();
        }

        [Route("Category/{categoryId}/SubCategory/{subCategoryId}")]
        [HttpGet]
        public IActionResult GetSubCategory(int categoryId, int subCategoryId)
        {
            return Ok(categoryId);
        }

        [Route("Category/{categoryId}/SubCategory")]
        [HttpPost]
        public IActionResult PostSubCategory(int categoryId, SubCategory subCategory)
        {

            //Add SubCategory to Category Table
            subCategory.CategoryId = categoryId;
            return Ok(subCategory);
        }

        [Route("Category/{categoryId}/SubCategory/{subCategoryId}")]
        [HttpPut]
        public IActionResult PutSubCategory(int categoryId, int subCategoryId, SubCategory subCategory)
        {
            return NoContent();
        }

        [Route("Category/{categoryId}/SubCategory/{subCategoryId}")]
        [HttpPatch]
        public IActionResult PatchSubCategory(int categoryId, int subCategoryId, SubCategory subCategory)//TODO Key-value
        {
            return NoContent();
        }

        [Route("Category/{categoryId}/SubCategory/{subCategoryId}")]
        [HttpDelete]
        public IActionResult DeleteSubCategory(int categoryId, int subCategoryId)
        {
            return NoContent();
        }

        //Product
        [Route("Category/{categoryId}/SubCategory/{subCategoryId}/Product")]
        [HttpGet]
        public IActionResult GetAllProducts(int categoryId, int subCategoryId)
        {
            return NoContent();
        }

        [Route("Category/{categoryId}/SubCategory/{subCategoryId}/Product/{productId}")]
        [HttpGet]
        public IActionResult GetProduct(int categoryId, int subCategoryId, int productId)
        {
            return NoContent();
        }

        [Route("Category/{categoryId}/SubCategory/{subCategoryId}/Product")]
        [HttpPost]
        public IActionResult PostProduct(int categoryId, int subCategoryId, Product product)
        {
            return NoContent();
        }

        [Route("Category/{categoryId}/SubCategory/{subCategoryId}/Product/{productId}")]
        [HttpPut]
        public IActionResult PutProduct(int categoryId, int subCategoryId, int productId, Product product)
        {
            return NoContent();
        }

        [Route("Category/{categoryId}/SubCategory/{subCategoryId}/Product/{productId}")]
        [HttpPatch]
        public IActionResult PatchProduct(int categoryId, int subCategoryId, int productId, Product product)//TODO Key-value
        {
            return NoContent();
        }

        [Route("Category/{categoryId}/SubCategory/{subCategoryId}/Product/{productId}")]
        [HttpDelete]
        public IActionResult DeleteProduct(int categoryId, int subCategoryId, int productId)
        {
            return NoContent();
        }

    }
}
