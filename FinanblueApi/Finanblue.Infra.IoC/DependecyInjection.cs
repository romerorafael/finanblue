using Finanblue.Application.Interfaces;
using Finanblue.Application.Services;
using Finanblue.Domain.Interfaces;
using Finanblue.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Finanblue.Infra.IoC
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyService, CompanyService>();

            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            services.AddScoped<IPurchaseService, PurchaseService>();

            services.AddScoped<IProductsPurchaseRepository, ProductsPurchaseRepository>();
            services.AddScoped<IProductsPurchaseService, ProductsPurchaseService>();

            return services;
        }
    }
}