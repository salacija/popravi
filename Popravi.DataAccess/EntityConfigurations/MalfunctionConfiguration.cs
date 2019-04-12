using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Popravi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Popravi.DataAccess.EntityConfigurations
{
    public class MalfunctionConfiguration : IEntityTypeConfiguration<Malfunction>
    {
        public void Configure(EntityTypeBuilder<Malfunction> builder)
        {
            builder.Property(m => m.Name).IsRequired().HasMaxLength(255);
            builder.HasIndex(m => m.Name).IsUnique();

            builder.Property(r => r.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(r => r.UpdatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(u => u.IsActive).HasDefaultValue(false);
        }
    }
    
}
