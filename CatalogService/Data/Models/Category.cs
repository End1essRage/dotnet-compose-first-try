using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogService.Data.Models
{
    [Table("categories")]
    public class Category : ModelBase
    {
        [Column("name")]
        public string Name { get; set; }
    }
}
