using Microsoft.EntityFrameworkCore;
using OnlineJobPortal.Data;
using OnlineJobPortal.Repository;
namespace OnlineJobPortal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("JobPortalCS")));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddTransient<IRecruiterRepository, RecruiterRepository>();
            builder.Services.AddTransient<IJobsRepository,JobsRepository>();
            builder.Services.AddTransient<IApplicationRepository, ApplicationRepository>();
            builder.Services.AddTransient<ICountryRepository, CountryRepository>(); 
            builder.Services.AddTransient<ICandidateRepository,CandidateRepository>();
            builder.Services.AddControllers().AddNewtonsoftJson();



            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
