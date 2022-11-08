using System.ComponentModel.DataAnnotations;

namespace fixxo_backend.Models.Entities.Product
{
    public class ColorEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Color { get; set; }


    }
}
