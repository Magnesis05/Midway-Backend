using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=WIN-CE4248RTEBP;Database=TestSQL;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Follows> Follows { get; set; }
        public DbSet<Posts> Posts { get; set; }

    }
}
