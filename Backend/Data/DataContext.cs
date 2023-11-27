using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using System.Reflection.Metadata;

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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
        .HasMany(e => e.Restaurants)
        .WithMany(e => e.AddressId)
        .UsingEntity("RestaurantsAddresses");

            modelBuilder.Entity<Allergies>()
        .HasMany(e => e.Users)
        .WithMany(e => e.Allergies)
        .UsingEntity("UsersAllergies");

            modelBuilder.Entity<Users>()
       .HasMany(e => e.Bookings_Id)
       .WithOne(e => e.booking_user_id);

            modelBuilder.Entity<Restaurants>()
            .HasMany(e => e.Bookings_Id)
            .WithOne(e => e.booking_restaurant_id);
        }
        
        public DbSet<Users> Users { get; set; }
        public DbSet<Allergies> Allergies { get; set; }
        public DbSet<Restaurants> Restaurants { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Bookings> Bookings { get; set; }

    }
}
