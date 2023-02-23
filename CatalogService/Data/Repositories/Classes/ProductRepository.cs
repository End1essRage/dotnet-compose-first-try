using CatalogService.Data.Models;
using CatalogService.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Data.Repositories.Classes
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
    }
}
