using Microsoft.EntityFrameworkCore;
using Popravi.DataAccess.Entities;
using Popravi.DataAccess.EntityConfigurations;

namespace Popravi.DataAccess
{
    public class PopraviDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=Popravi;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
            
        public DbSet<Role> Roles { get; set; }
    }
}