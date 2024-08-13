using OnlineJobPortal.Models;

namespace OnlineJobPortal.Repository
{
    public interface IJobsRepository
    {
        Task<List<Job>> GetAllJobsAsync();

        Task<Job> GetJobByIdAsync(int JobID);

        Task<int> AddJobAsync(Job job);

        Task UpdateJobByIDAsync(int JobID, Job job);

        Task DeleteJobByIDAsync(int JobID);
    }
}
