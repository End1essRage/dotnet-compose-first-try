using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogService.Data.Entities
{
    [Table("subcategories")]
    public class SubCategory : EntityBase
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("category_id")]
        public int CategoryId { get; set; }
    }
}
