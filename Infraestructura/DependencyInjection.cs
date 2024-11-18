using Core.DTOs.Card;
using Core.DTOs.Charge;
using Core.DTOs.Customer;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Requests;
using FluentValidation;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Infrastructure.Validations;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositories();
            services.AddDatabase(configuration);
            services.AddValidations();
            services.AddMapping();
            services.AddServices();
            
            return services;
        }

        //metodo de extension
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<IChargeRepository, ChargeRepository>();
            services.AddScoped<IEntityRepository, EntityRepository>();

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
            services.AddScoped<IValidator<CreateCardDTO>, CreateCardValidation>();
            services.AddScoped<IValidator<CreateChargeDTO>, CreateChargeValidation>();
            services.AddScoped<IValidator<CreateEntityRequest>, CreateEntityValidation>();
            services.AddScoped<IValidator<UpdateEntityRequest>, UpdateEntityValidation>();
            return services;
        }

        public static IServiceCollection AddMapping(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
            
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<IEntityService, EntityService>();

            return services;
        }
    }

}
