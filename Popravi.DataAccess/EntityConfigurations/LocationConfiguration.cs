using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Popravi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Popravi.DataAccess.EntityConfigurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.Property(l => l.Name).IsRequired().HasMaxLength(60);

            builder.HasOne(l => l.City).WithMany(c => c.Locations).OnDelete(DeleteBehavior.Cascade);

            builder.Property(r => r.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(r => r.UpdatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(u => u.IsActive).HasDefaultValue(false);
        }
    }
}
