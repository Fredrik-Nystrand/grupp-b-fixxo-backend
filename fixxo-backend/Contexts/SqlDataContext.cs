using fixxo_backend.Models.Entities.Customer;
using fixxo_backend.Models.Entities.Order;
using fixxo_backend.Models.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace fixxo_backend.Contexts
{
    public class SqlDataContext : DbContext
    {
        public SqlDataContext(DbContextOptions<SqlDataContext> options) : base(options)
        {
        }

        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ColorEntity> Colors { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<SizeEntity> Sizes { get; set; }
        public DbSet<SubCategoryEntity> SubCategories { get; set; }
        public DbSet<OrderProductEntity> OrderProducts { get; set; }
    }
}
