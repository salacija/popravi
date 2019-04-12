using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Popravi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Popravi.DataAccess.EntityConfigurations
{
   public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(40);
            builder.HasIndex(c => c.Name).IsUnique();
            builder.Property(c => c.ZipCode).IsRequired().HasMaxLength(5);
            builder.HasIndex(c => c.ZipCode).IsUnique();

            builder.Property(c => c.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(c => c.UpdatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(c => c.IsActive).HasDefaultValue(true);
        }
    }
}
