using CatalogService.Data.Entities;

namespace CatalogService.Data.DataAccess.Interfaces
{
    public interface ISubCategoryRepository : IAsyncRepository<SubCategory>
    {
        Task<List<SubCategory>> GetSubCategoriesAsync(int categoryId);
        Task<SubCategory> AddSubCategoryAsync(int categoryId, SubCategory entity);
    }
}
