using OnlineJobPortal.Models;

namespace OnlineJobPortal.Repository
{
    public interface IJobsRepository
    {
        Task<List<Job>> GetAllJobsAsync();
        Task<Job> GetJobByIdAsync(int JobID);
        Task<Job> GetJobByNameAsync(string jobName);
        Task<int> AddJobAsync(Job job);
        Task<string> UpdateJobByIDAsync(int JobID, Job job);
        Task DeleteJobByIDAsync(int JobID);
        Task<Job> GetJobByRecruiterIdAsync(int rID);
    }
}
