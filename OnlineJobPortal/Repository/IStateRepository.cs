using OnlineJobPortal.Models;

namespace OnlineJobPortal.Repository
{
    public interface IStateRepository
    {
        Task<List<State>> GetAllStateAsync();

        Task<Country> GetStateByIdAsync(int StateID);
        Task<int> AddStateAsync(State state);

        Task UpdateStateByIDAsync(int StateID, State state);

        Task DeleteStateByIDAsync(int StateID);
    }
}
