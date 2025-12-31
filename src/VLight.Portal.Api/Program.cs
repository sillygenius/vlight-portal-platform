using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using VLight.Portal.Application;
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
            // DbContext 配置增强
            // -----------------------
            // 获取连接字符串并验证
            var connectionString = builder.Configuration.GetConnectionString("Default");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("ConnectionStrings:Default", "数据库连接字符串未配置，请检查appsettings.json");
            }

            builder.Services.AddDbContext<PortalDbContext>(options =>
            {
                // 配置MySQL连接
                options.UseMySql(
                    connectionString,
                    ServerVersion.AutoDetect(connectionString),
                    optionsBuilder =>
                    {
                        // 配置迁移程序集（如果迁移文件不在当前项目）
                        optionsBuilder.MigrationsAssembly("VLight.Portal.EntityFrameworkCore");
                        // 配置连接超时时间（可选）
                        optionsBuilder.CommandTimeout(30);
                    });

                // 开发环境下启用详细日志
                if (builder.Environment.IsDevelopment())
                {
                    options.EnableSensitiveDataLogging(); // 显示敏感数据（生产环境禁用）
                    options.LogTo(Console.WriteLine, LogLevel.Information); // 输出SQL日志
                }
            });

            // 添加数据库迁移支持（可选，用于程序启动时自动迁移）
            builder.Services.AddHostedService<DbMigrationHostedService>();

            // -----------------------
            // Identity（如果需要可取消注释并完善）
            // -----------------------
            //builder.Services
            //    .AddIdentity<ApplicationUser, ApplicationRole>(options =>
            //    {
            //        // 配置密码策略等
            //        options.Password.RequireDigit = true;
            //        options.Password.RequiredLength = 8;
            //    })
            //    .AddEntityFrameworkStores<PortalDbContext>()
            //    .AddDefaultTokenProviders();


            // -----------------------
            // JWT Authentication（保持不变）
            // -----------------------
            var jwtSection = builder.Configuration.GetSection("Jwt");
            var jwtKey = jwtSection["Key"] ?? throw new ArgumentNullException("Jwt:Key", "JWT密钥未配置");

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
            // 应用服务配置
            // -----------------------
            builder.Services.AddApplication(); // 取消注释以启用应用层服务


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

    // 数据库迁移托管服务（用于自动迁移）
    public class DbMigrationHostedService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public DbMigrationHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<PortalDbContext>();

            // 自动应用迁移（生产环境建议谨慎使用）
            await dbContext.Database.MigrateAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}