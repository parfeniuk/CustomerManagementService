using CustomerManagementService.Domain.Models;

namespace CustomerManagementService.Domain.Contracts.Services
{
    public interface ICustomersService
    {
        Task<IEnumerable<CustomerModel>> GetCustomersAsync();

        Task<CustomerModel> GetCustomerByIdAsync(int id);

        Task<bool> CreateCustomersAsync(IEnumerable<CustomerModel> customers);
    }
}
