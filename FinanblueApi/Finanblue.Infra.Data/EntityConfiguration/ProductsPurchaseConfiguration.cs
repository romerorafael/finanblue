using Finanblue.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanblue.Infra.Data.EntityConfiguration
{
    internal class ProductsPurchaseConfiguration : IEntityTypeConfiguration<ProductsPurchase>
    {
        public void Configure(EntityTypeBuilder<ProductsPurchase> builder)
        {
            builder.Property(p => p.Id).IsRequired().UseIdentityColumn().HasIdentityOptions(1,1);
            builder.Property(p => p.ProductId).IsRequired();
            builder.Property(p => p.PurchaseId).IsRequired();

            builder.HasKey(p => p.Id);

        }
    }
}
