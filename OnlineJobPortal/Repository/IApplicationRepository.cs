using OnlineJobPortal.Models;

namespace OnlineJobPortal.Repository
{
    public interface IApplicationRepository
    {
        Task<List<Application>> GetAllApplicationsAsync();

        Task<Application> GetApplicationByIdAsync(int ApplicationID);

        Task<int> AddApplicationAsync(Application application);

        Task UpdateApplicationByIDAsync(int ApplicationID, Application application);

        Task DeleteApplicationByIDAsync(int ApplicationID);
        //Task GetApplicationByCandidateIdAsync(int canID);

        Task <List<Application>> GetApplicationByCandidateIdAsync(int canID);

        Task<List<Application>> GetApplicationByJobIdAsync(int jobID);
    }
}
