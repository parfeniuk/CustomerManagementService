namespace CustomerManagementService.Domain.Contracts.Services
{
    public interface ICustomersValidationService
    {
        Task<bool> Exists(int id);
    }
}
