using System.ComponentModel.DataAnnotations;

namespace fixxo_backend.Models.Entities.Order
{
    public class OrderProductsEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int ColorId { get; set; }

        [Required]
        public int SizeId { get; set; }

        [Required]
        public int OrderId { get; set; }
    }
}
