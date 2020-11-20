using System;
using Ecommerce.Data;
using Ecommerce.Repository;
using Ecommerce.Service.Services;
using Ecommerce.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;

namespace Ecommerce.Service
{
    public static class ServiceExtension
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductService, ProductService>();
        }

        public static void ConfigureDatabase(this IServiceCollection services, string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new Exception($"Connection string not set!");

            services.AddDbContext<EcommerceContext>(options => options.UseNpgsql(connectionString));

            var serviceProvider = services.BuildServiceProvider();
            var db = serviceProvider.GetRequiredService<EcommerceContext>();
            db.Database.EnsureCreated();
            db.Database.Migrate();
        }
    }
}