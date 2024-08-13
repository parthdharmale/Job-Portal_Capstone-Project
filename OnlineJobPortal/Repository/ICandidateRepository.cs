using OnlineJobPortal.Models;

namespace OnlineJobPortal.Repository
{
    public interface ICandidateRepository
    {
        Task<List<Candidate>> GetAllCandidatesAsync();

        Task<Candidate> GetCandidateByIdAsync(int CID);

        Task<int> AddCandidateAsync(Candidate candidate);

        Task UpdateCandidateByIDAsync(int CID, Candidate candidate);

        Task DeleteCandidateByIDAsync(int CID);
    }
}
