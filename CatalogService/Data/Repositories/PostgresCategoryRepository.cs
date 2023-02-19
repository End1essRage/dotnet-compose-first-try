using CatalogService.Data.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace CatalogService.Data.Repositories
{
    public class PostgresCategoryRepository : ICategoryRepository
    {

        private readonly DataContext _dataContext;


        public PostgresCategoryRepository(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }

        public List<Category> GetAllCategories()
        {
            return _dataContext.Categories.AsNoTracking().ToList();
        }

        public Category GetCategory(int categoryId)
        {
            var category = _dataContext.Categories.Find(categoryId);

            if (category is null)
            {
                throw new InvalidOperationException("category does not exists");
            }

            return category;
        }

        public Category AddCategory(Category category)
        {
            int categoryId = 1;
            var lastCategory = _dataContext.Categories.OrderBy(categories => categories.Id).LastOrDefault();
            if (lastCategory is not null)
            {
                categoryId = lastCategory.Id + 1;
            }

            category.Id = categoryId;

            _dataContext.Categories.Add(category);
            _dataContext.SaveChanges();
            return category;
        }
        public void UpdateCategory(Category category)
        {
            var categoryToUpdate = _dataContext.Categories.Find(category.Id);
            if (categoryToUpdate is null)
            {
                throw new InvalidOperationException("category does not exist");
            }

            categoryToUpdate.Name = category.Name;

            _dataContext.Categories.Update(categoryToUpdate);
            _dataContext.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = _dataContext.Categories.Find(categoryId);
            if (category is null)
            {
                throw new InvalidOperationException("category does not exists");
            }

            _dataContext.Categories.Remove(category);
            _dataContext.SaveChanges();
        }
    }
}
