using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Popravi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Popravi.DataAccess.EntityConfigurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(a => a.StreetName).IsRequired().HasMaxLength(50);
            builder.Property(a => a.ZipCode).IsRequired().HasMaxLength(5);
            builder.Property(a => a.HomeNumber).HasMaxLength(7);

            builder.HasIndex(a => a.ZipCode).IsUnique();

            builder.Property(a => a.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(a => a.UpdatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(a => a.IsActive).HasDefaultValue(true);

            builder.HasOne(a => a.City).WithMany().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
