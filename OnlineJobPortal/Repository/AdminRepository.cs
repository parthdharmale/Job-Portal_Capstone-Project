using JobPortalModels.Models;
using Microsoft.EntityFrameworkCore;
using OnlineJobPortal.Data;
using OnlineJobPortal.Models;

namespace OnlineJobPortal.Repository
{
    public class AdminRepository : IAdminRepository
    {

        private readonly ApplicationDbContext _context;
        public AdminRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Admin>> GetAllAdminAsync()
        {
            var records = await _context.Admins.Select(u => new Admin()
            {
                AdminID = u.AdminID,
                AdminName = u.AdminName,
                UserName = u.UserName,
                Password = u.Password
            }).ToListAsync();

            return records;
        }

        public async Task<int> AddAdminAsync(Admin admin)
        {
            var newadmin = new Admin()
            {
                AdminID = admin.AdminID,
                AdminName = admin.AdminName,
                UserName = admin.UserName,
                Password = admin.Password
            };
            _context.Admins.Add(newadmin);
            await _context.SaveChangesAsync();

            return newadmin.AdminID;
        }

        public async Task UpdateAdminByIDAsync(int AdminID, Admin admin)
        {
            var updatedAdmin = await _context.Admins.FindAsync(AdminID);

            if (updatedAdmin != null)
            {
                //updatedCountry.CountryID = country.CountryID;
                updatedAdmin.AdminName = admin.AdminName;
                updatedAdmin.UserName = admin.UserName;
                updatedAdmin.Password = admin.Password;

            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAdminByIDAsync(int AdminID)
        {
            var deletedAdmin = new Admin()
            {
                AdminID = AdminID,
            };

            _context.Admins.Remove(deletedAdmin);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CheckAdminCredentialsAsync(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Username and password must be provided.");
            }

            var admin = await _context.Admins
                                           .FirstOrDefaultAsync(c => c.UserName == username && c.Password == password);

            return admin?.AdminID ?? 0;
        }
    }
}
