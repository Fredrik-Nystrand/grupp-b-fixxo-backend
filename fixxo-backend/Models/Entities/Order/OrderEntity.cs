using fixxo_backend.Models.Entities.Customer;
using fixxo_backend.Models.Entities.Product;
using System.ComponentModel.DataAnnotations;

namespace fixxo_backend.Models.Entities.Order
{
    public class OrderEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TotalProducts { get; set; }

        [Required]
        public int TotalPrice { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public DateTime Modified { get; set; }

        public IEnumerable<OrderProductEntity> Products { get; set; }

        public CustomerEntity Customer { get; set; }
    }
}
