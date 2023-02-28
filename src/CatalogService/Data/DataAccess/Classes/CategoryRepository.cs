using CatalogService.Data.DataAccess;
using CatalogService.Data.Entities;
using CatalogService.Data.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace CatalogService.Data.DataAccess.Classes
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly DbSet<Category> _categories;

        public CategoryRepository(DataContext dataContext) : base(dataContext)
        {
            _context = dataContext;
            _categories = _context.Set<Category>();
        }
    }
}
