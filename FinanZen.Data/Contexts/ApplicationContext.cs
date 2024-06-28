using FinanZen.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanZen.Data.Contexts;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }
    
    public DbSet<UserBill> UserBills { get; set; }
    
    public DbSet<UserEarning> UserEarnings { get; set; }
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Tables
        modelBuilder.Entity<User>()
            .ToTable("Users");

        modelBuilder.Entity<UserBill>()
            .ToTable("UserBills");

        modelBuilder.Entity<UserEarning>()
            .ToTable("UserEarnings");
        
        // Primary Keys
        modelBuilder.Entity<User>()
            .HasKey(user => user.Id);

        modelBuilder.Entity<UserBill>()
            .HasKey(userBill => userBill.Id);

        modelBuilder.Entity<UserEarning>()
            .HasKey(userEarning => userEarning.Id);
        
        // Relationships
        modelBuilder.Entity<User>()
            .HasMany<UserBill>(user => user.UserBills)
            .WithOne(userBill => userBill.User)
            .HasForeignKey(userBill => userBill.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<User>()
            .HasMany<UserEarning>(user => user.UserEarnings)
            .WithOne(userEarning => userEarning.User)
            .HasForeignKey(userEarning => userEarning.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}