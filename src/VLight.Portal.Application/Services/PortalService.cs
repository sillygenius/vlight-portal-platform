// ================================
// Services / PortalService.cs
// ================================
using Microsoft.EntityFrameworkCore;
using VLight.Portal.Application.Contracts;
using VLight.Portal.Application.DTOs.Portal;
using VLight.Portal.EntityFrameworkCore.DbContexts;


namespace VLight.Portal.Application.Services;


/// <summary>
/// 门户聚合服务（首页核心）
/// </summary>
public class PortalService : IPortalService
{
    private readonly IUserService _userService;
    private readonly IResourceService _resourceService;
    private readonly PortalDbContext _db;
    private readonly ICurrentUser _currentUser;


    public PortalService(
    IUserService userService,
    IResourceService resourceService,
    PortalDbContext db,
    ICurrentUser currentUser)
    {
        _userService = userService;
        _resourceService = resourceService;
        _db = db;
        _currentUser = currentUser;
    }


    public async Task<PortalHomeDto> GetPortalHomeAsync()
    {
        var user = await _userService.GetCurrentUserAsync();
        var menus = await _resourceService.GetUserResourcesAsync();


        // 获取角色对应的首页模板（优先级：第一个匹配）
        var homeTemplate = await _db.RolePageTemplates
        .Where(rp => _currentUser.Roles.Contains(rp.Role!.Name!))
        .Select(rp => rp.PageTemplate!)
        .FirstOrDefaultAsync(pt => pt.Published);


        return new PortalHomeDto
        {
            User = user,
            Menus = menus,
            HomePage = homeTemplate == null
        ? null
        : new PageTemplateDto(
        homeTemplate.Id,
        homeTemplate.Code,
        homeTemplate.Name,
        homeTemplate.SchemaJson)
        };
    }
}
