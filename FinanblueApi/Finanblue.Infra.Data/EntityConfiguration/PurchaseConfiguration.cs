using Finanblue.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Finanblue.Infra.Data.EntityConfiguration
{
    public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.Property(p => p.Id).IsRequired().UseIdentityColumn().HasIdentityOptions(1, 1);
            builder.Property(p => p.Total).HasPrecision(15, 2).IsRequired();
            builder.Property(p => p.CompanyId).IsRequired();

            builder.HasKey(p => p.Id);

        }
    }
}
