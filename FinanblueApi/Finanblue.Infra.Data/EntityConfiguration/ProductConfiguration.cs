using Finanblue.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finanblue.Infra.Data.EntityConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired().UseIdentityColumn().HasIdentityOptions(1, 1);
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(200);
            builder.Property(p => p.Price).HasPrecision(15, 2).IsRequired();

            builder.HasKey(p => p.Id);

        }

    }
}
