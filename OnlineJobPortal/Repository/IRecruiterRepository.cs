using OnlineJobPortal.Models;
namespace OnlineJobPortal.Repository
{
    public interface IRecruiterRepository
    {
        Task<List<Recruiter>> GetAllRecruitersAsync();

        Task<Recruiter> GetRecruiterByIdAsync(int RID);

        Task<int> AddRecruiterAsync(Recruiter recruiter);

        Task UpdateRecruiterByIDAsync(int RID, Recruiter recruiter);

        Task DeleteRecruiterByIDAsync(int RID);


    }
}
