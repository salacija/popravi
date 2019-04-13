using Microsoft.EntityFrameworkCore;
using Popravi.DataAccess.Entities;
using Popravi.DataAccess.EntityConfigurations;
using System;

namespace Popravi.DataAccess
{
    public class PopraviDbContext : DbContext
    {
        public PopraviDbContext()
        {

        }

        public PopraviDbContext(DbContextOptions options) : base(options) { }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new MalfunctionConfiguration());

            modelBuilder.Entity<Role>().HasData(new Role { Id = Role.UserRoleId, Name = "User", CreatedAt = DateTime.Now, IsActive = true });
            modelBuilder.Entity<Role>().HasData(new Role { Id = Role.AdminRoleId, Name = "Admin", CreatedAt = DateTime.Now, IsActive = true });
        }
            
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Malfunction> MalFunctions { get; set; }
    }
}