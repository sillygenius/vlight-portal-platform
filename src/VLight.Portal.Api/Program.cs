using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using VLight.Portal.Application;
//using VLight.Portal.Application.Abstractions;
using VLight.Portal.EntityFrameworkCore;
using VLight.Portal.EntityFrameworkCore.Entities.Identity;
using VLight.Portal.Api.Infrastructure;
using VLight.Portal.EntityFrameworkCore.DbContexts;

namespace VLight.Portal.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // -----------------------
            // DbContext
            // -----------------------
            builder.Services.AddDbContext<PortalDbContext>(options =>
            {
                var conn = builder.Configuration.GetConnectionString("Default");
                options.UseMySql(conn, ServerVersion.AutoDetect(conn));
            });


            // -----------------------
            // Identity
            // -----------------------
            //builder.Services
            //.AddIdentity<ApplicationUser, ApplicationRole>()
            //.AddEntityFrameworkStores<PortalDbContext>()
            //.AddDefaultTokenProviders();


            // -----------------------
            // JWT Authentication
            // -----------------------
            var jwtSection = builder.Configuration.GetSection("Jwt");
            var jwtKey = jwtSection["Key"]!;


            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSection["Issuer"],
                    ValidAudience = jwtSection["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                };
            });


            // -----------------------
            // Application services
            // -----------------------
            //builder.Services.AddApplication();


            // Current user (HTTP ¡ú Application)
           // builder.Services.AddScoped<ICurrentUser, CurrentUser>();


            var app = builder.Build();


            // =======================
            // HTTP pipeline
            // =======================


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();


            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();


            app.Run();
        }
    }
}
