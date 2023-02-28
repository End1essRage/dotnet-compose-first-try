using CatalogService.Data.DataAccess;
using CatalogService.Data.Entities;
using CatalogService.Data.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Data.DataAccess.Classes
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly DbSet<Product> _products;

        public ProductRepository(DataContext dataContext) : base(dataContext)
        {
            _context = dataContext;
            _products = _context.Set<Product>();
        }

        public async Task<Product> AddProductAsync(int subCategoryId, Product entity)
        {
            entity.SubCategoryId = subCategoryId;
            _products.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Product>> GetProductsAsync(int subCategoryId)
        {
            return await _products.Where(s => s.SubCategoryId == subCategoryId).ToListAsync();
        }

        public async Task<List<Product>> GetProductsByListIdsAsync(List<int> productIds)
        {
            return await _products.Where(s => productIds.Contains(s.Id)).ToListAsync();
        }
    }
}
