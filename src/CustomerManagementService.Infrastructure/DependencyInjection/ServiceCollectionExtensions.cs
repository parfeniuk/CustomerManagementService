using CustomerManagementService.Domain.Contracts.Repositories;
using CustomerManagementService.Infrastructure.Database.Configuration;
using CustomerManagementService.Infrastructure.Database.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerManagementService.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services) 
        {
            services.AddSingleton<IConnectionStringProvider, ConnectionStringProvider>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<ICustomersValidationRepository, CustomersValidationRepository>();

            return services;
        }
    }
}
