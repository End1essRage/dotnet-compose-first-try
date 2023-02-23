using CatalogService.Data.Models;
using CatalogService.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Data.Repositories.Classes
{
    public class SubCategoryRepository : BaseRepository<SubCategory>, ISubCategoryRepository
    {
        private readonly DbSet<SubCategory> _subcategories;

        public SubCategoryRepository(DataContext dataContext) : base(dataContext)
        {
            _context = dataContext;
            _subcategories = _context.Set<SubCategory>();
        }

        public async Task<SubCategory> AddSubCategoryAsync(int categoryId, SubCategory entity)
        {
            entity.CategoryId = categoryId;
            _subcategories.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<SubCategory>> GetSubCategoriesAsync(int categoryId)
        {
            return await _subcategories.Where(s => s.CategoryId == categoryId).ToListAsync();
        }
    }
}
