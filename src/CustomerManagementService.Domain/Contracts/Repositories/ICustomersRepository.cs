using CustomerManagementService.Domain.Entities;

namespace CustomerManagementService.Domain.Contracts.Repositories
{
    public interface ICustomersRepository
    {
        Task<IEnumerable<CustomerEntity>> GetCustomersAsync();

        Task<CustomerEntity> GetCustomerByIdAsync(int id);

        Task<bool> CreateCustomersAsync(IEnumerable<CustomerEntity> customers);
    }
}
