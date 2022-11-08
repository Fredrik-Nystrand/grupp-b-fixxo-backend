using System.ComponentModel.DataAnnotations;

namespace fixxo_backend.Models.Entities.Product
{
    public class SubCategoryEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]

        public string CategoryName { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
