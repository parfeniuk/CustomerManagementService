using CustomerManagementService.Domain.Contracts.Repositories;
using CustomerManagementService.Domain.Contracts.Services;

namespace CustomerManagementService.Application.Services
{
    public class CustomersValidationService : ICustomersValidationService
    {
        private readonly ICustomersValidationRepository _customersValidationRepository;

        public CustomersValidationService(ICustomersValidationRepository customersValidationRepository)
        {
            _customersValidationRepository = customersValidationRepository;
        }

        public Task<bool> Exists(int id)
        {
            return _customersValidationRepository.Exists(id);
        }
    }
}
