using Microsoft.EntityFrameworkCore;
using OnlineJobPortal.Data;
using OnlineJobPortal.Models;
using System.Security.Cryptography;

namespace OnlineJobPortal.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Application>> GetAllApplicationsAsync()
        {
            var records = await _context.Applications.Select(u => new Application()
            {
                ApplicationID = u.ApplicationID,
                JobID = u.JobID,
                CID = u.CID,
                Resume = u.Resume,
                Skills = u.Skills,
                Status = u.Status,
                DateOfApplication = u.DateOfApplication,
            }).ToListAsync();
            return records;

        }

        public async Task<Application> GetApplicationByIdAsync(int ApplicationID)
        {
            var records = _context.Applications.Where(u => u.ApplicationID == ApplicationID).Select(u => new Application()
            {
                ApplicationID = u.ApplicationID,
                JobID = u.JobID,
                CID = u.CID,
                Resume = u.Resume,
                Skills = u.Skills,
                Status = u.Status,
                DateOfApplication = u.DateOfApplication,
            }).FirstOrDefault();
            return records;
        }

        public async Task<int> AddApplicationAsync(Application application)
        {
            var newApplication = new Application()
            {
                JobID = application.JobID,
                CID = application.CID,
                Resume = application.Resume,
                Skills = application.Skills,
                Status = application.Status,
                DateOfApplication = application.DateOfApplication
            };
            _context.Applications.Add(newApplication);
            await _context.SaveChangesAsync();

            return newApplication.ApplicationID;
        }

        public async Task UpdateApplicationByIDAsync(int ApplicationID, Application application)
        {
            var updatedApplication = await _context.Applications.FindAsync(ApplicationID);

            if (updatedApplication != null)
            {
                updatedApplication.CID = application.CID;
                updatedApplication.Resume = application.Resume;
                updatedApplication.Skills = application.Skills;
                updatedApplication.Status = application.Status;
                updatedApplication.DateOfApplication = application.DateOfApplication;
            }

            await _context.SaveChangesAsync();
        }


        public async Task DeleteApplicationByIDAsync(int ApplicationID)
        {

            var deletedApplication = new Application()
            {
                ApplicationID = ApplicationID,
            };

            _context.Applications.Remove(deletedApplication);
            await _context.SaveChangesAsync();
        }



    }
}
