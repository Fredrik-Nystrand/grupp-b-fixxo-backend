using System.ComponentModel.DataAnnotations;

namespace fixxo_backend.Models.Entities.Product
{
    public class ProductColorsEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ColorId { get; set; }

        [Required]
        public int ProductId { get; set; }
    }
}
