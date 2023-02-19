namespace CatalogService.Data.Models
{
    public class Product : ModelBase
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public int SubCategoryId { get; set; }
    }
}
