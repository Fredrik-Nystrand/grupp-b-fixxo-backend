using System.ComponentModel.DataAnnotations;

namespace fixxo_backend.Models.Entities.Product
{
    public class CategoryEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]

        public string CategoryName { get; set; }

    }
}
