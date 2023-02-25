using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogService.Data.Entities
{
    [Table("categories")]
    public class Category : EntityBase
    {
        [Column("name")]
        public string Name { get; set; }
    }
}
