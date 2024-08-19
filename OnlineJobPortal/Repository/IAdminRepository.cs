using JobPortalModels.Models;

namespace OnlineJobPortal.Repository
{
    public interface IAdminRepository
    {
        Task<List<Admin>> GetAllAdminAsync();
        Task<int> AddAdminAsync(Admin admin);
        Task UpdateAdminByIDAsync(int AdminID, Admin admin);
        Task DeleteAdminByIDAsync(int AdminID);
        Task<int> CheckAdminCredentialsAsync(string username, string password);
    }
}
