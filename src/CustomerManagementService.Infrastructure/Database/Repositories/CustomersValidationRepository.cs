using CustomerManagementService.Domain.Contracts.Repositories;
using CustomerManagementService.Infrastructure.Database.Configuration;
using CustomerManagementService.Infrastructure.Database.Metadata;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CustomerManagementService.Infrastructure.Database.Repositories
{
    public class CustomersValidationRepository : ICustomersValidationRepository
    {
        private readonly IConnectionStringProvider _connectionStringProvider;

        public CustomersValidationRepository(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
        }

        public async Task<bool> Exists(int id)
        {
            var query = @$"SELECT CASE WHEN EXISTS
            (
                SELECT * FROM {CustomerManagementDatabaseTables.Customers}
                  WHERE Id=@id
            ) THEN 1 ELSE 0 END AS IdExists";

            await using var connection = new SqlConnection(_connectionStringProvider.CustomerManagementService);
            await connection.OpenAsync();

            return await connection.ExecuteScalarAsync<bool>(query, new { id });
        }
    }
}
