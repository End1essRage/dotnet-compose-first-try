using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogService.Data.Models
{
    public class ModelBase
    {
        [Column("_id")]
        public int Id { get; set; }
    }
}
