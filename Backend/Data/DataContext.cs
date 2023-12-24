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

      

            modelBuilder.Entity<User>()
       .HasMany(e => e.Bookings_Id)
       .WithOne(e => e.booking_user_id);

            modelBuilder.Entity<Restaurants>()
            .HasMany(e => e.Bookings_Id)
            .WithOne(e => e.booking_restaurant_id);

            modelBuilder.Entity<UserAllergies>()
                    .HasKey(pc => new { pc.UserId, pc.AllergieId });
            modelBuilder.Entity<UserAllergies>()
                    .HasOne(p => p.User)
                    .WithMany(pc => pc.UserAllergies)
                    .HasForeignKey(p => p.UserId);
            modelBuilder.Entity<UserAllergies>()
                    .HasOne(p => p.Allergies)
                    .WithMany(pc => pc.UserAllergies)
                    .HasForeignKey(c => c.AllergieId);
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Allergies> Allergies { get; set; }
        public DbSet<UserAllergies> UserAllergies { get; set; }
        public DbSet<Restaurants> Restaurants { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Bookings> Bookings { get; set; }

    }
}
