using Data.Entities.UserManagement;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserToAddress> UserToAddresses { get; set; }
        public DbSet<Addresses> Addresses { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<UserToAddress>()
        //        .HasKey(ua => new { ua.UserId, ua.AddressId });

        //    modelBuilder.Entity<UserToAddress>()
        //        .HasOne(ua => ua.Users)
        //        .WithMany(u => u.UserToAddresses)
        //        .HasForeignKey(ua => ua.UserId);

        //    modelBuilder.Entity<UserToAddress>()
        //        .HasOne(ua => ua.Addresses)
        //        .WithMany(a => a.Users)
        //        .HasForeignKey(ua => ua.AddressId);
        //}
    }
}
