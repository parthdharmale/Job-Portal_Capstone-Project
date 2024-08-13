using OnlineJobPortal.Models;

namespace OnlineJobPortal.Repository
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllCountryAsync();

        Task<Country> GetCountryByIdAsync(int CountryID);
        Task<int> AddCountryAsync(Country country);

        Task UpdateCountryByIDAsync(int CountryID, Country country);

        Task DeleteCountryByIDAsync(int CountryID);

    }
}
