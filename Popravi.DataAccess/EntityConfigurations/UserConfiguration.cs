using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Popravi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Popravi.DataAccess.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(20);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(30);
            builder.Property(u => u.Username).IsRequired().HasMaxLength(20);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(32);
            builder.Property(u => u.ActivationCode).HasMaxLength(100);
            builder.Property(u => u.Email).IsRequired();

            builder.HasIndex(u => u.Username).IsUnique();
            builder.HasIndex(u => u.Email).IsUnique();
            builder.HasIndex(u => u.ActivationCode).IsUnique();

            builder.Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(u => u.UpdatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(u => u.IsActive).HasDefaultValue(false);

            builder.HasOne(u => u.Role).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(u => u.Addresses).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
