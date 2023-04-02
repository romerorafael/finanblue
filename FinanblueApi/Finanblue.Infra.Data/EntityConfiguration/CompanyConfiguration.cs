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
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(p => p.Id).IsRequired().UseIdentityColumn().HasIdentityOptions(1, 1);
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Activity).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Cnpj).HasMaxLength(20);

            builder.HasKey(p => p.Id);

        }
    }
}
