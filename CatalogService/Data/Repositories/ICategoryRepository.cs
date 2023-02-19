using CatalogService.Data.Models;

namespace CatalogService.Data.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();
        Category GetCategory(int categoryId);
        Category AddCategory(Category category);
        void DeleteCategory(int categoryId);
        void UpdateCategory(Category category);
    }
}
