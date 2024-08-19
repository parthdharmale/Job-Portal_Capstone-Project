using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NLog.Web;
using OnlineJobPortal.Data;
using OnlineJobPortal.Repository;
using System.Text;
namespace OnlineJobPortal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure NLog for ASP.NET Core
            builder.Logging.ClearProviders(); // Clears default logging providers.
            builder.Host.UseNLog(); // Use NLog as the logging provider.
            // Add services to the container.
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });
            builder.Services.AddControllers();
            builder.Services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("JobPortalCS")));
            builder.Services.AddCors(options => options.AddPolicy("CorsEmpPolicy", policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddTransient<IRecruiterRepository, RecruiterRepository>();
            builder.Services.AddTransient<IJobsRepository,JobsRepository>();
            builder.Services.AddTransient<IApplicationRepository, ApplicationRepository>();
            builder.Services.AddTransient<ICountryRepository, CountryRepository>(); 
            builder.Services.AddTransient<ICandidateRepository,CandidateRepository>();
            builder.Services.AddTransient<ICityRepository, CityRepository>();
            builder.Services.AddTransient<IStateRepository, StateRepository>();
            builder.Services.AddTransient<IAdminRepository, AdminRepository>();
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

            app.UseCors("CorsEmpPolicy");


            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
