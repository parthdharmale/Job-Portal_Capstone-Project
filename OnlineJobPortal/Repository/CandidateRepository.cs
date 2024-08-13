using Microsoft.EntityFrameworkCore;
using OnlineJobPortal.Data;
using OnlineJobPortal.Models;
using System;
using System.Net;
using static System.Net.Mime.MediaTypeNames;

namespace OnlineJobPortal.Repository
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly ApplicationDbContext _context;

        public CandidateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Candidate>> GetAllCandidatesAsync()
        {
            var records = await _context.Candidates.Select(u => new Candidate()
            {
                CID = u.CID,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Password = u.Password,
                DOB = u.DOB,
                Address = u.Address,
                Contact = u.Contact,
                CityID = u.CityID,
                Education1 = u.Education1,
                Education2 = u.Education2,
                Education3 = u.Education3,
                Workex1 = u.Workex1,
                Workex2 = u.Workex2,
                Workex3 = u.Workex3,
            }).ToListAsync();

            return records;
        }

        public async Task<Candidate> GetCandidateByIdAsync(int CID)
        {
            var records = _context.Candidates.Where(u => u.CID == CID).Select(u =>new Candidate()
            {
                CID = u.CID,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Password = u.Password,
                DOB = u.DOB,
                Address = u.Address,
                Contact = u.Contact,
                CityID = u.CityID,
                Education1 = u.Education1,
                Education2 = u.Education2,
                Education3 = u.Education3,
                Workex1 = u.Workex1,
                Workex2 = u.Workex2,
                Workex3 = u.Workex3,
            }).FirstOrDefault();

            return records;
        }

        public async Task<int> AddCandidateAsync(Candidate candidate)
        {
            var newCandidate = new Candidate()
            {
                CID = candidate.CID,
                FirstName = candidate.FirstName,
                LastName = candidate.LastName,
                Email = candidate.Email,
                Password = candidate.Password,
                DOB = candidate.DOB,
                Address = candidate.Address,
                Contact = candidate.Contact,
                CityID = candidate.CityID,
                Education1 = candidate.Education1,
                Education2 = candidate.Education2,
                Education3 = candidate.Education3,
                Workex1 = candidate.Workex1,
                Workex2 = candidate.Workex2,
                Workex3 = candidate.Workex3,
            };
            _context.Candidates.Add(newCandidate);
            await _context.SaveChangesAsync();

            return newCandidate.CID;
        }

        public async Task UpdateCandidateByIDAsync(int CID, Candidate candidate)
        {
            var updatedCandidate = await _context.Candidates.FindAsync(CID);

            if (updatedCandidate != null)
            {
                updatedCandidate.CID = candidate.CID;
                updatedCandidate.FirstName = candidate.FirstName;
                updatedCandidate.LastName = candidate.LastName;
                updatedCandidate.Email = candidate.Email;
                updatedCandidate.Password = candidate.Password;
                updatedCandidate.DOB = candidate.DOB;
                updatedCandidate.Address = candidate.Address;
                updatedCandidate.Contact = candidate.Contact;
                updatedCandidate.CityID = candidate.CityID;
                updatedCandidate.Education1 = candidate.Education1;
                updatedCandidate.Education2 = candidate.Education2;
                updatedCandidate.Education3 = candidate.Education3;
                updatedCandidate.Workex1 = candidate.Workex1;
                updatedCandidate.Workex2 = candidate.Workex2;
                updatedCandidate.Workex3 = candidate.Workex3;
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteCandidateByIDAsync(int CID)
        {
            var deletedCandidate = new Candidate()
            {
                CID = CID,
            };

            _context.Candidates.Remove(deletedCandidate);
            await _context.SaveChangesAsync();
        }
    }
}
