using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogService.Data.Models
{
    [Table("products")]
    public class Product : ModelBase
    {
        [Column("name")]
        public string Name { get; set; }
        [Column("amount")]
        public int Amount { get; set; }
        [Column("price")]
        public double Price { get; set; }
        [Column("subcategory_id")]
        public int SubCategoryId { get; set; }
    }
}
