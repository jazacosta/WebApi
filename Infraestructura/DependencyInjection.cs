﻿using Core.Interfaces.Repositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        //metodo de extension
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}
