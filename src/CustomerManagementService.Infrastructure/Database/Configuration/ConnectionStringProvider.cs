using Microsoft.Extensions.Configuration;

namespace CustomerManagementService.Infrastructure.Database.Configuration
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private readonly IConfiguration _configuration;
        public ConnectionStringProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CustomerManagementService => _configuration.GetConnectionString(nameof(CustomerManagementService));
    }
}
