using System.ComponentModel.DataAnnotations;

namespace fixxo_backend.Models.Categories
{
    public class SubCategoryRequest
    {
        [Required]
        public string CategoryName { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
