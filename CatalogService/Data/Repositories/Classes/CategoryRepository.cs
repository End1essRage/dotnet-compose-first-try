using CatalogService.Data.Models;
using CatalogService.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace CatalogService.Data.Repositories.Classes
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
