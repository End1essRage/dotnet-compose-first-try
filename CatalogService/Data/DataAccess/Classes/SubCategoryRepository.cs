using CatalogService.Data.Entities;
using CatalogService.Data.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using CatalogService.Data.DataAccess;

namespace CatalogService.Data.DataAccess.Classes
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
