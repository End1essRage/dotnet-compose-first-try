using CatalogService.Data.Models;

namespace CatalogService.Data.Repositories.Interfaces
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
        Task<List<Product>> GetProductsAsync(int subCategoryId);
        Task<Product> AddProductAsync(int subCategoryId, Product entity);
    }
}
