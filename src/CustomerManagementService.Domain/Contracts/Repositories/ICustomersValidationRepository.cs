namespace CustomerManagementService.Domain.Contracts.Repositories
{
    public interface ICustomersValidationRepository
    {
        Task<bool> Exists(int id);
    }
}
