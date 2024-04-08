using AutoMapper;
using CustomerManagementService.Domain.Entities;
using CustomerManagementService.Domain.Models;

namespace CustomerManagementService.Application.Mappers
{
    public class CustomerManagementServiceMappingProfile : Profile
    {
        public CustomerManagementServiceMappingProfile()
        {
            CreateMap<CustomerModel,CustomerEntity>().ReverseMap();
        }
    }
}
