using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace fixxo_backend.Models.Entities.Product
{
    public class ColorEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Color { get; set; }

        [JsonIgnore]
        public IEnumerable<ProductEntity> Products { get; set; }
    }
}
