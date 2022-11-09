using fixxo_backend.Models.Entities.Order;
using System.ComponentModel.DataAnnotations;

namespace fixxo_backend.Models.Entities.Customer
{
    public class CustomerEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        public IEnumerable<OrderEntity> Orders { get; set; }
    }
}
