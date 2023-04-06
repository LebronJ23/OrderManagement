using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OM.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OM.Infrastructure
{
    public static class DIExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:OrderConnection"];
            services.AddDbContext<OrdersDbContext>(opts => 
            {
                opts.UseSqlServer(connectionString);
                opts.EnableSensitiveDataLogging(true);
            });
            services.AddScoped<IOrdersDbContext>(provider => provider.GetService<OrdersDbContext>());
            return services;
        }
    }
}
