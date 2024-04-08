using AutoMapper;
using CustomerManagementService.Domain.Contracts.Repositories;
using CustomerManagementService.Domain.Contracts.Services;
using CustomerManagementService.Domain.Entities;
using CustomerManagementService.Domain.Models;

namespace CustomerManagementService.Application.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IMapper _mapper;
        private readonly SortedSet<CustomerModel> _customers;

        public CustomersService(
            ICustomersRepository customersRepository,
            IMapper mapper)
        {
            _customersRepository = customersRepository;
            _mapper = mapper;
            _customers = [];
        }

        public async Task<bool> CreateCustomersAsync(IEnumerable<CustomerModel> customers)
        {
            _customers.UnionWith(customers);

            return await _customersRepository.CreateCustomersAsync(_mapper.Map<IEnumerable<CustomerEntity>>(customers));
        }

        public async Task<CustomerModel> GetCustomerByIdAsync(int id)
        {
            if(_customers.Any(c => c.Id == id))
            {
                return _customers.First(c => c.Id == id);
            }

            var result = await _customersRepository.GetCustomerByIdAsync(id);

            return _mapper.Map<CustomerModel>(result);
        }

        public async Task<IEnumerable<CustomerModel>> GetCustomersAsync()
        {
            var result = await _customersRepository.GetCustomersAsync();

            return _mapper.Map<IEnumerable<CustomerModel>>(result);
        }
    }
}
