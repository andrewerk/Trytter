﻿using Application.Boundaries;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbService(this IServiceCollection services)
        {
            services.AddScoped<ITrytterContext, TrytterContext>();
            services.AddScoped<ITrytterRepository, TrytterRepository>();

            return services;
        }
    }
}
