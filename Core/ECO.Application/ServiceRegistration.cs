﻿using ECO.Application.Abstractions.Services;
using ECO.Application.Repositories;
using ECO.Application.Repositories.Order;
using ECO.Domain.Configuration;
using ECO.Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            
            services.AddMediatR(typeof(ServiceRegistration));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            var serverConf = new EcoServerConfiguration();            
            services.AddSingleton(serverConf);
           


        }
    }
}
