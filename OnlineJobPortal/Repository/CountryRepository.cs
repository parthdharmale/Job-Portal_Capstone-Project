using Microsoft.EntityFrameworkCore;
using OnlineJobPortal.Data;
using OnlineJobPortal.Models;

namespace OnlineJobPortal.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;
        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Country>> GetAllCountryAsync()
        {
            var records = await _context.Countries.Select(u => new Country()
            {
                CountryID = u.CountryID,
                CountryName = u.CountryName,
            }).ToListAsync();

            return records;
        }

        public async Task<Country> GetCountryByIdAsync(int CountryID)
        {
            var records = _context.Countries.Where(u => u.CountryID == CountryID).Select(u=>new Country()
            {
                CountryID = u.CountryID,
                CountryName = u.CountryName,
            }).FirstOrDefault();

            return records;
        }

        public async Task<int> AddCountryAsync(Country country)
        {
            var newcountry = new Country()
            {
                CountryID = country.CountryID,
                CountryName = country.CountryName,
            };
            _context.Countries.Add(newcountry);
            await _context.SaveChangesAsync();

            return newcountry.CountryID;
        }

        public async Task UpdateCountryByIDAsync(int CountryID, Country country)
        {
            var updatedCountry = await _context.Countries.FindAsync(CountryID);

            if(updatedCountry != null)
            {
                updatedCountry.CountryID = country.CountryID;
                updatedCountry.CountryName = country.CountryName;

            }

            await _context.SaveChangesAsync();  
        }

        public async Task DeleteCountryByIDAsync(int CountryID)
        {
            var deletedCountry = new Country()
            {
                CountryID = CountryID,
            };

            _context.Countries.Remove(deletedCountry);
            await _context.SaveChangesAsync();
        }
    }
}
