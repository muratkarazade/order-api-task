using ECO.Application.Abstractions.Services;
using ECO.Application.Repositories;
using ECO.Application.Repositories.Order;
using ECO.Domain.Entities;
using ECO.EnvironmentConfiguration;
using ECO.Persistence.Context;
using ECO.Persistence.Repositories;
using ECO.Persistence.Repositories.Order;
using ECO.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.ConnectionString), ServiceLifetime.Scoped);

            #region Repositories
            //services.AddScoped<ITestReadRepository, TestReadRepository>();

            //services.AddScoped<IReadRepository<Order, int>, OrderReadRepository>();

            //services.AddScoped<IWriteRepository<Order, int>, OrderWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

            #endregion

            #region Services
            //services.AddScoped<INotificationService, NotificationService>();

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<EnvironmentConfig>();

            #endregion
        }
    }
}
