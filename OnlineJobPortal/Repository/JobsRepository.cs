using Microsoft.EntityFrameworkCore;
using OnlineJobPortal.Data;
using OnlineJobPortal.Models;
using System.Security.Cryptography;

namespace OnlineJobPortal.Repository
{
    public class JobsRepository : IJobsRepository
    {
        private readonly ApplicationDbContext _context;

        public JobsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Job>> GetAllJobsAsync()
        {
            var records = await _context.Jobs.Select(u => new Job()
            {
                JobID = u.JobID,
                RID = u.RID,
                Description = u.Description,
                Location = u.Location,
                Skills = u.Skills,
                RecruiterContact = u.RecruiterContact,
                RecruiterEmail = u.RecruiterEmail,
                RecruiterName = u.RecruiterName,
                JobPostDate = u.JobPostDate,
                JobExpireDate = u.JobExpireDate,
                ModeOfWork = u.ModeOfWork
            }).ToListAsync();
            return records;
        }

        public async Task<Job> GetJobByIdAsync(int JobID)
        {
            var records = _context.Jobs.Where(u => u.JobID == JobID).Select(u => new Job()
            {
                JobID = u.JobID,
                RID = u.RID,
                Description = u.Description,
                Location = u.Location,
                Skills = u.Skills,
                RecruiterContact = u.RecruiterContact,
                RecruiterEmail = u.RecruiterEmail,
                RecruiterName = u.RecruiterName,
                JobPostDate = u.JobPostDate,
                JobExpireDate = u.JobExpireDate,
                ModeOfWork = u.ModeOfWork
            }).FirstOrDefault();
            return records;
        }

        public async Task<int> AddJobAsync(Job job)
        {
            var newjob = new Job()
            {
                RID = job.RID,
                Description = job.Description,
                Location = job.Location,
                Skills = job.Skills,
                RecruiterContact = job.RecruiterContact,
                RecruiterEmail = job.RecruiterEmail,
                RecruiterName = job.RecruiterName,
                JobPostDate = job.JobPostDate,
                JobExpireDate = job.JobExpireDate,
                ModeOfWork = job.ModeOfWork
            };
            _context.Jobs.Add(newjob);
            await _context.SaveChangesAsync();

            return newjob.RID;
        }

        public async Task UpdateJobByIDAsync(int JobID, Job job)
        {
            var updatedJob = await _context.Jobs.FindAsync(JobID);
            if(updatedJob != null)
            {
                updatedJob.Description = job.Description;
                updatedJob.Location = job.Location;
                updatedJob.Skills = job.Skills;
                updatedJob.RecruiterContact = job.RecruiterContact;
                updatedJob.RecruiterEmail = job.RecruiterEmail;
                updatedJob.RecruiterName = job.RecruiterName;
                updatedJob.JobPostDate = job.JobPostDate;
                updatedJob.JobExpireDate = job.JobExpireDate;
                updatedJob.ModeOfWork = job.ModeOfWork;
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteJobByIDAsync(int JobID)
        {
            var deletedJob = new Job()
            {
                JobID = JobID,
            };
            _context.Jobs.Remove(deletedJob);
            await _context.SaveChangesAsync();
        }
    }
}
