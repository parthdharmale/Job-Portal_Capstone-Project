using JobPortalModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineJobPortal.Models;
namespace OnlineJobPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Application> Applications { get; set; }

        public DbSet<Candidate> Candidates { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<Recruiter> Recruiters { get; set; }

        public DbSet<Admin> Admins { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("server=IN-5CG4151CSD; database=Test; Integrated Security = True; TrustServerCertificate= true; MultipleActiveResultSets = true;");
        //}

    }
}
