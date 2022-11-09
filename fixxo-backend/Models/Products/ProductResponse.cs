using fixxo_backend.Models.Entities.Product;
using System.ComponentModel.DataAnnotations;

namespace fixxo_backend.Models.Products
{
    public class ProductResponse
    {
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public IEnumerable<ColorEntity> Colors { get; set; }
        public IEnumerable<SizeEntity> Sizes { get; set; }
        public CategoryEntity Category { get; set; }
        public SubCategoryEntity SubCategory { get; set; }

    }
}
