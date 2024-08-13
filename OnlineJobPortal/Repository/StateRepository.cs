using Microsoft.EntityFrameworkCore;
using OnlineJobPortal.Data;
using OnlineJobPortal.Models;

namespace OnlineJobPortal.Repository
{
    public class StateRepository
    {
        private readonly ApplicationDbContext _context;
        public StateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<State>> GetAllStateAsync()
        {
            var records = await _context.States.Select(u => new State()
            {
                StateID = u.CountryID,
                StateName = u.StateName,
                CountryID = u.CountryID
            }).ToListAsync();

            return records;
        }

        public async Task<State> GetStateByIdAsync(int StateID)
        {
            var records = _context.States.Where(u => u.StateID == StateID).Select(u => new State()
            {
                StateID = u.StateID,
                StateName = u.StateName,
            }).FirstOrDefault();

            return records;
        }

        public async Task<int> AddStateAsync(State state)
        {
            var newState = new State()
            {
                StateID = state.StateID,
                StateName = state.StateName,
                CountryID = state.CountryID
            };
            _context.States.Add(newState);
            await _context.SaveChangesAsync();

            return newState.StateID;
        }

        public async Task UpdateStateByIDAsync(int StateID, State state)
        {
            var updatedState = await _context.States.FindAsync(StateID);

            if (updatedState != null)
            {
                updatedState.StateID = state.StateID;
                updatedState.StateName = state.StateName;
                updatedState.CountryID = state.CountryID;

            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteStateByIDAsync(int StateID)
        {
            var deletedState = new State()
            {
                StateID = StateID,
            };

            _context.States.Remove(deletedState);
            await _context.SaveChangesAsync();
        }
    }
}
