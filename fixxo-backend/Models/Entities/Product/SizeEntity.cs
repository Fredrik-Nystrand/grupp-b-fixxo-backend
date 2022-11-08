using System.ComponentModel.DataAnnotations;

namespace fixxo_backend.Models.Entities.Product
{
    public class SizeEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Size { get; set; }
    }
}
