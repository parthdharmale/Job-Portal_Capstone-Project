﻿using Microsoft.AspNetCore.JsonPatch;
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
                StateID = u.StateID,
                CountryID = u.CountryID,
                Education1 = u.Education1,
                EducationResult1 = u.EducationResult1,
                EducationPassoutYear1 = u.EducationPassoutYear1,
                Education2 = u.Education2,
                EducationResult2 = u.EducationResult2,
                EducationPassoutYear2 = u.EducationPassoutYear2,
                Education3 = u.Education3,
                EducationResult3 = u.EducationResult3,
                EducationPassoutYear3 = u.EducationPassoutYear3,
                Workex1 = u.Workex1,
                WorkexDesc1 = u.WorkexDesc1,
                Workex2 = u.Workex2,
                WorkexDesc2 = u.WorkexDesc2,
                Workex3 = u.Workex3,
                WorkexDesc3 = u.WorkexDesc3
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
                StateID = u.StateID,
                CountryID = u.CountryID,
                Education1 = u.Education1,
                EducationResult1 = u.EducationResult1,
                EducationPassoutYear1 = u.EducationPassoutYear1,
                Education2 = u.Education2,
                EducationResult2 = u.EducationResult2,
                EducationPassoutYear2 = u.EducationPassoutYear2,
                Education3 = u.Education3,
                EducationResult3 = u.EducationResult3,
                EducationPassoutYear3 = u.EducationPassoutYear3,
                Workex1 = u.Workex1,
                WorkexDesc1 = u.WorkexDesc1,
                Workex2 = u.Workex2,
                WorkexDesc2 = u.WorkexDesc2,
                Workex3 = u.Workex3,
                WorkexDesc3 = u.WorkexDesc3
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
                StateID = candidate.StateID,
                CountryID  = candidate.CountryID,
                Education1 = candidate.Education1,
                EducationResult1 = candidate.EducationResult1,
                EducationPassoutYear1 = candidate.EducationPassoutYear1,
                Education2 = candidate.Education2,
                EducationResult2 = candidate.EducationResult2,
                EducationPassoutYear2 = candidate.EducationPassoutYear2,
                Education3 = candidate.Education3,
                EducationResult3 = candidate.EducationResult3,
                EducationPassoutYear3 = candidate.EducationPassoutYear3,
                Workex1 = candidate.Workex1,
                WorkexDesc1 = candidate.WorkexDesc1,
                Workex2 = candidate.Workex2,
                WorkexDesc2 = candidate.WorkexDesc2,
                Workex3 = candidate.Workex3,
                WorkexDesc3 = candidate.WorkexDesc3
            };
            _context.Candidates.Add(newCandidate);
            await _context.SaveChangesAsync();

            return newCandidate.CID;
        }
        public async Task UpdateCandidateByIDAsync(int CID, JsonPatchDocument candidates)
        {
            var updateCandidate = await _context.Candidates.FindAsync(CID);
            if (updateCandidate != null)
            {
                candidates.ApplyTo(updateCandidate);
                await _context.SaveChangesAsync();
            }
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

        public async Task<int> CheckCandidateCredentialsAsync(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Email and password must be provided.");
            }

            var candidate = await _context.Candidates
                                           .FirstOrDefaultAsync(c => c.Email == email && c.Password == password);

            return candidate?.CID ?? 0;
        }

    }
}
