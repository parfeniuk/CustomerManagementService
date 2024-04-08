using CustomerManagementService.Application.Mappers;
using CustomerManagementService.Application.Services;
using CustomerManagementService.Domain.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerManagementService.Application.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CustomerManagementServiceMappingProfile));
            services.AddScoped<ICustomersService, CustomersService>();
            services.AddScoped<ICustomersValidationService, CustomersValidationService>();
            
            return services;
        }
    }
}
