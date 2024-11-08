using Core.DTOs;
using Core.Interfaces.Repositories;
using FluentValidation;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Infrastructure.Validations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Bootcamp");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            return services;
        
        }
        public static IServiceCollection AddValidations(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateCustomerDTO>, CreateValidation>();
            services.AddScoped<IValidator<UpdateCustomerDTO>, UpdateValidation>();
            return services;
        }
    }

}
