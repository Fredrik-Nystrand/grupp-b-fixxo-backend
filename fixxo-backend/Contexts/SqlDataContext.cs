using Microsoft.EntityFrameworkCore;

namespace fixxo_backend.Contexts
{
    public class SqlDataContext : DbContext
    {
        public SqlDataContext(DbContextOptions<SqlDataContext> options) : base(options)
        {
        }

        //input entitys
    }
}
