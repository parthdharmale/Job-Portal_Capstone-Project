using Microsoft.AspNetCore.JsonPatch;
using OnlineJobPortal.Models;

namespace OnlineJobPortal.Repository
{
    public interface ICandidateRepository
    {
        Task<List<Candidate>> GetAllCandidatesAsync();
        Task<Candidate> GetCandidateByIdAsync(int CID);
        Task<int> AddCandidateAsync(Candidate candidate);
        Task UpdateCandidateByIDAsync(int CID, JsonPatchDocument candidates);
        Task DeleteCandidateByIDAsync(int CID);

        Task<int> CheckCandidateCredentialsAsync(string email, string password);
    }
}
