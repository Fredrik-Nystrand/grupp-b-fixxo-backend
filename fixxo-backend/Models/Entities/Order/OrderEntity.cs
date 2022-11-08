using System.ComponentModel.DataAnnotations;

namespace fixxo_backend.Models.Entities.Order
{
    public class OrderEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderProductsId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int TotalProducts { get; set; }

        [Required]
        public int TotalPrice { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public DateTime Modified { get; set; }
    }
}
