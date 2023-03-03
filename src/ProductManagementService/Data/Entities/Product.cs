using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagementService.Data.Entities
{
    [Table("products")]
    public class Product
    {
        [Column("_id")]
        public int Id { get; }
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
