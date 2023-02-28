using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CatalogService.Data.Entities
{
    [Table("products")]
    public class Product : EntityBase
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
