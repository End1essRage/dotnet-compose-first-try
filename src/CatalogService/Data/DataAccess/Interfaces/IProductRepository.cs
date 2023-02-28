using CatalogService.Data.Entities;

namespace CatalogService.Data.DataAccess.Interfaces
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
        Task<List<Product>> GetProductsAsync(int subCategoryId);
        Task<Product> AddProductAsync(int subCategoryId, Product entity);
        Task<List<Product>> GetProductsByListIdsAsync(List<int> productIds);
    }
}
