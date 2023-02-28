using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogService.Data.Entities
{
    public class EntityBase
    {
        [Column("_id")]
        public int Id { get; }
    }
}
