using fixxo_backend.Models.Entities.Product;
using System.ComponentModel.DataAnnotations;

namespace fixxo_backend.Models.Entities.Order
{
    public class OrderProductEntity
    {
        [Key]
        public int Id { get; set; }

        public ProductEntity product { get; set; }

        public ColorEntity color { get; set; }

        public SizeEntity size { get; set; }

        public OrderEntity order { get; set; }
    }
}
