using fixxo_backend.Models.Entities.Order;
using fixxo_backend.Models.Entities.Product;
using System.ComponentModel.DataAnnotations;

namespace fixxo_backend.Models.Products
{
    public class ProductRequest
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string ImgUrl { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public decimal SalePrice { get; set; }

        public decimal Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int SubCategoryId { get; set; }

        public int[] Colors { get; set; }

        public int[] Sizes { get; set; }

    }
}
