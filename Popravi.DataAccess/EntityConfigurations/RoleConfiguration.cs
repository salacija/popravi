using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Popravi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Popravi.DataAccess.EntityConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(20);

            builder
                .HasIndex(r => r.Name)
                .IsUnique();

            builder.Property(r => r.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(r => r.UpdatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
