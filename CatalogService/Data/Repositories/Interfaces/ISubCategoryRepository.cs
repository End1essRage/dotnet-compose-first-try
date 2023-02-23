using CatalogService.Data.Models;

namespace CatalogService.Data.Repositories.Interfaces
{
    public interface ISubCategoryRepository : IAsyncRepository<SubCategory>
    {
        Task<List<SubCategory>> GetSubCategoriesAsync(int categoryId);
        Task<SubCategory> AddSubCategoryAsync(int categoryId, SubCategory entity);
    }
}
