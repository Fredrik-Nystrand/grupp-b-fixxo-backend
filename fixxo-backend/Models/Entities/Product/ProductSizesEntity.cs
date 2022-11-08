using System.ComponentModel.DataAnnotations;

namespace fixxo_backend.Models.Entities.Product
{
    public class ProductSizesEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SizeId { get; set; }

        [Required]
        public int ProductId { get; set; }
    }
}
