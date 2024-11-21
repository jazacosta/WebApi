using Core.DTOs.Card;
using Core.DTOs.Charge;
using Core.DTOs.Customer;
using Core.DTOs.Payment;
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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


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
            services.AddAuth();
            
            return services;
        }

        //extension method
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<IChargeRepository, ChargeRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IEntityRepository, EntityRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

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
            services.AddScoped<IValidator<CreatePaymentDTO>, CreatePaymentValidation>();
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
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }

        public static IServiceCollection AddAuth(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false, 
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConfig.Secret))
                };
            });

            

            services.AddTransient<AuthService>();

            return services;
        }

    }

}
