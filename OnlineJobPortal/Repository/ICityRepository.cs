using OnlineJobPortal.Models;

namespace OnlineJobPortal.Repository
{
    public interface ICityRepository
    {
        Task<List<City>> GetAllCityAsync();

        Task<Country> GetCityByIdAsync(int CityID);
        Task<int> AddCityAsync(City city);

        Task UpdateCityByIDAsync(int CityID, City city);

        Task DeleteCityByIDAsync(int CityID);
    }
}
