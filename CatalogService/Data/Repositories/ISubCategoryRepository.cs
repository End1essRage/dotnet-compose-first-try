using CatalogService.Data.Models;

namespace CatalogService.Data.Repositories
{
    public interface ISubCategoryRepository
    {
        IEnumerable<SubCategory> GetAllSubCategories();
        SubCategory GetSubCategory(int subCategoryId);
        void AddSubCategory(SubCategory subCategory);
        void DeleteSubCategory(int subCategoryId);
        void UpdateSubCategory(SubCategory subCategory);
        void Save();
    }
}
