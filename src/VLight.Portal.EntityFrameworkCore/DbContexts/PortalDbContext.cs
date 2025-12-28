// ================================
// DbContexts / PortalDbContext.cs
// ================================
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VLight.Portal.EntityFrameworkCore.Entities.Identity;
using VLight.Portal.EntityFrameworkCore.Entities.Organization;
using VLight.Portal.EntityFrameworkCore.Entities.Authorization;
using VLight.Portal.EntityFrameworkCore.Entities.Portal;
using VLight.Portal.EntityFrameworkCore.Entities.Audit;


namespace VLight.Portal.EntityFrameworkCore.DbContexts;


/// <summary>
/// 智慧电厂门户系统主 DbContext
/// </summary>
public class PortalDbContext : IdentityDbContext<ApplicationUser>
{
    public PortalDbContext(DbContextOptions<PortalDbContext> options)
    : base(options) { }


    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Resource> Resources => Set<Resource>();
    public DbSet<RoleResource> RoleResources => Set<RoleResource>();


    public DbSet<PortalApplication> PortalApplications => Set<PortalApplication>();
    public DbSet<PageTemplate> PageTemplates => Set<PageTemplate>();
    public DbSet<RolePageTemplate> RolePageTemplates => Set<RolePageTemplate>();


    public DbSet<LoginLog> LoginLogs => Set<LoginLog>();
    public DbSet<OperationLog> OperationLogs => Set<OperationLog>();


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


        // Department
        builder.Entity<Department>()
        .HasMany(d => d.Children)
        .WithOne(d => d.Parent)
        .HasForeignKey(d => d.ParentId);


        // Resource
        builder.Entity<Resource>()
        .HasIndex(r => r.Code)
        .IsUnique();


        // RoleResource composite key
        builder.Entity<RoleResource>()
        .HasKey(rr => new { rr.RoleId, rr.ResourceId });


        // RolePageTemplate composite key
        builder.Entity<RolePageTemplate>()
        .HasKey(rp => new { rp.RoleId, rp.PageTemplateId });
    }
}
