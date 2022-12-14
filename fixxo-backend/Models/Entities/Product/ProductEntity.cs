using fixxo_backend.Models.Entities.Order;
using System.ComponentModel.DataAnnotations;

namespace fixxo_backend.Models.Entities.Product
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ImgUrl { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public decimal SalePrice { get; set; }

        public decimal Rating { get; set; } = 0;

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int SubCategoryId { get; set; }

        public IEnumerable<ColorEntity> Colors { get; set; }

        public IEnumerable<SizeEntity> Sizes { get; set; }

    }
}
