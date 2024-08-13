using Microsoft.EntityFrameworkCore;
using OnlineJobPortal.Data;
using OnlineJobPortal.Models;

namespace OnlineJobPortal.Repository
{
    public class CityRepository
    {
        private readonly ApplicationDbContext _context;
        public CityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<City>> GetAllCityAsync()
        {
            var records = await _context.Cities.Select(u => new City()
            {
                CityID = u.CityID,
                CityName = u.CityName,
                StateID = u.StateID
            }).ToListAsync();

            return records;
        }

        public async Task<City> GetCityByIdAsync(int CityID)
        {
            var records = _context.Cities.Where(u => u.CityID == CityID).Select(u => new City()
            {
                CityID = u.CityID,
                CityName = u.CityName,
                StateID = u.StateID
            }).FirstOrDefault();

            return records;
        }

        public async Task<int> AddCityAsync(City city)
        {
            var newCity = new City()
            {
                CityID = city.CityID,
                CityName = city.CityName,
                StateID = city.StateID
            };
            _context.Cities.Add(newCity);
            await _context.SaveChangesAsync();

            return newCity.CityID;
        }

        public async Task UpdateCityByIDAsync(int CityID, City city)
        {
            var updatedCity = await _context.Cities.FindAsync(CityID);

            if (updatedCity != null)
            {
                updatedCity.CityID = city.CityID;
                updatedCity.CityName = city.CityName;
                updatedCity.StateID = city.StateID;

            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteCityByIDAsync(int CityID)
        {
            var deletedCity = new City()
            {
                CityID = CityID,
            };

            _context.Cities.Remove(deletedCity);
            await _context.SaveChangesAsync();
        }
    }
}
