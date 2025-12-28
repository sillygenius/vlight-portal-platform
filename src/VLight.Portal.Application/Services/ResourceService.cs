// ================================
// Services / ResourceService.cs
// ================================
using Microsoft.EntityFrameworkCore;
using VLight.Portal.Application.Contracts;
using VLight.Portal.Application.DTOs.Authorization;
using VLight.Portal.EntityFrameworkCore.DbContexts;
using VLight.Portal.EntityFrameworkCore.Entities.Authorization;


namespace VLight.Portal.Application.Services;


/// <summary>
/// 权限资源服务（RBAC 核心）
/// </summary>
public class ResourceService : IResourceService
{
    private readonly PortalDbContext _db;
    private readonly ICurrentUser _currentUser;


    public ResourceService(PortalDbContext db, ICurrentUser currentUser)
    {
        _db = db;
        _currentUser = currentUser;
    }


    public async Task<IEnumerable<ResourceDto>> GetUserResourcesAsync()
    {
        // 通过角色获取授权资源
        var resources = await _db.RoleResources
        .Where(rr => _currentUser.Roles.Contains(rr.Role!.Name!))
        .Select(rr => rr.Resource!)
        .Where(r => r.Type == ResourceType.Menu)
        .Distinct()
        .OrderBy(r => r.Sort)
        .ToListAsync();


        return resources.Select(r => new ResourceDto(
        r.Id,
        r.Code,
        r.Name,
        r.Type.ToString()
        ));
    }
}
