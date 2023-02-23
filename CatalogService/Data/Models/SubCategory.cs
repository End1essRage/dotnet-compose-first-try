using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogService.Data.Models
{
    [Table("subcategories")]
    public class SubCategory : ModelBase
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("category_id")]
        public int CategoryId { get; set; }
    }
}
