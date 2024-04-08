using CustomerManagementService.Domain.Contracts.Services;
using CustomerManagementService.Domain.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementService.WebAPI.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase 
    {
        private readonly ICustomersService _customersService;
        private readonly IValidator<CustomerModel> _customerModelValidator;

        public CustomersController(
            ICustomersService customersService,
            IValidator<CustomerModel> customerModelValidator)
        {
            _customersService = customersService;
            _customerModelValidator = customerModelValidator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CustomerModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCustomersAsync()
        {
            var customers = await _customersService.GetCustomersAsync();

            if (customers == null || !customers.Any())
            {
                return NotFound();
            }

            return Ok(customers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CustomerModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCustomerByIdAsync(int id)
        {
            var customer = await _customersService.GetCustomerByIdAsync(id);

            if (customer is null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCustomersAsync(IEnumerable<CustomerModel> customers)
        {

            foreach (var customer in customers)
            {
                var validationResult = await _customerModelValidator.ValidateAsync(customer);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }
            }

            var result = await _customersService.CreateCustomersAsync(customers);

            if (!result)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok();
        }
    }
}
