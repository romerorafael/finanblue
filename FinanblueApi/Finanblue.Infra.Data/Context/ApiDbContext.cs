using Finanblue.Domain.Entities;
using Finanblue.Infra.Data.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Finanblue.Infra.Data.Context
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext() { }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(
                "Server=localhost;Database=FinanblueDb;Port=5432;User Id=postgres;Password=#H@unt3r;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseConfiguration());
            modelBuilder.ApplyConfiguration(new ProductsPurchaseConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());


            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    Id = 1,
                    Name = "Niantic",
                    Activity = "Jogos e derivados",
                    Cnpj = "44788866/0001-9"
                },
                new Company
                {
                    Id = 2,
                    Name = "Blizzard",
                    Activity = "Jogos e derivados",
                    Cnpj = "55877733/0001-9"
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Caneta Preta",
                    Description = "Uma caneta bic preta",
                    Price = (decimal)1.50
                },
                new Product
                {
                    Id = 2,
                    Name = "Caneta Azul",
                    Description = "Uma caneta bic azul",
                    Price = (decimal)1.50
                },
                new Product
                {

                    Id= 3,
                    Name = "Borracha Ben10",
                    Description = "Uma borracha do Ben10",
                    Price = (decimal)3.50
                },
                new Product
                {

                    Id= 4,
                    Name = "Lapiz Pokemon",
                    Description = "Lapiz do Pokemon",
                    Price = (decimal)0.55
                }
            );

            modelBuilder.Entity<Purchase>().HasData
            (
                new Purchase
                {
                    Id = 1,
                    Total = (decimal)1.1,
                    CompanyId = 1,               
                }
            );


            modelBuilder.Entity<ProductsPurchase>().HasData(
                new ProductsPurchase
                {
                    Id = 1,
                    ProductId = 1,
                    PurchaseId = 1,
                },
                new ProductsPurchase
                {
                    Id = 2,
                    ProductId = 1,
                    PurchaseId = 1,
                }
            );


        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchase { get; set; } 
        public DbSet<Company> Company { get; set; }
        public DbSet<ProductsPurchase> ProductsPurchase { get; set; }
    }
}
