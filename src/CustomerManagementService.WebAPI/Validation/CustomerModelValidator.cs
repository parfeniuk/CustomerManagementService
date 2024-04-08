using CustomerManagementService.Domain.Contracts.Services;
using CustomerManagementService.Domain.Models;
using FluentValidation;

namespace CustomerManagementService.WebAPI.Validation
{
    public class CustomerModelValidator : AbstractValidator<CustomerModel>
    {
        private const int MinAge = 18;
        private readonly ICustomersValidationService _customersValidationService;

        public CustomerModelValidator(ICustomersValidationService customersValidationService)
        {
            _customersValidationService = customersValidationService;

            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Age).GreaterThan(MinAge);

            RuleFor(x => x.Id)
                .MustAsync(async (id, token) => 
                {
                    var exists = await _customersValidationService.Exists(id);
                    return !exists;
                })
                .WithMessage(x => $"Customer with id {x.Id} already exists.");
        }
    }
}
