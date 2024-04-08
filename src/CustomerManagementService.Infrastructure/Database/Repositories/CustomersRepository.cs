using CustomerManagementService.Domain.Contracts.Repositories;
using CustomerManagementService.Domain.Entities;
using CustomerManagementService.Infrastructure.Database.Configuration;
using CustomerManagementService.Infrastructure.Database.Helpers;
using CustomerManagementService.Infrastructure.Database.Metadata;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CustomerManagementService.Infrastructure.Database.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly IConnectionStringProvider _connectionStringProvider;

        public CustomersRepository(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
        }

        public async Task<bool> CreateCustomersAsync(IEnumerable<CustomerEntity> customers)
        {
            var customersDataTable = customers.ToCustomersDataTable();

            await using var connection = new SqlConnection(_connectionStringProvider.CustomerManagementService);
            await connection.OpenAsync();

            using var transaction = connection.BeginTransaction();
            {
                using var sqlBulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transaction);
                {
                    sqlBulkCopy.DestinationTableName = CustomerManagementDatabaseTables.Customers;

                    try
                    {
                        await sqlBulkCopy.WriteToServerAsync(customersDataTable);
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();

                        return false;
                    }
                }

                await transaction.CommitAsync();

                return true;
            }

        }

        public async Task<CustomerEntity> GetCustomerByIdAsync(int id)
        {
            var query = @$"
                SELECT {nameof(CustomerEntity.Id)}, {nameof(CustomerEntity.Age)}, {nameof(CustomerEntity.FirstName)}, {nameof(CustomerEntity.LastName)}
                FROM {CustomerManagementDatabaseTables.Customers}
                WHERE {nameof(CustomerEntity.Id)} = @id";

            await using var connection = new SqlConnection(_connectionStringProvider.CustomerManagementService);
            await connection.OpenAsync();

            return await connection.QuerySingleOrDefaultAsync<CustomerEntity>(
                query,
                new { id }
                );
        }

        public async Task<IEnumerable<CustomerEntity>> GetCustomersAsync()
        {
            var query = @$"
                SELECT {nameof(CustomerEntity.Id)}, {nameof(CustomerEntity.Age)}, {nameof(CustomerEntity.FirstName)}, {nameof(CustomerEntity.LastName)}
                FROM {CustomerManagementDatabaseTables.Customers}";

            await using var connection = new SqlConnection(_connectionStringProvider.CustomerManagementService);
            await connection.OpenAsync();

            return await connection.QueryAsync<CustomerEntity>(query);
        }
    }
}
