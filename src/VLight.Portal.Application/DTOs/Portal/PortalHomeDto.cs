// ================================
// DTOs / Portal / PortalHomeDto.cs
// ================================
using VLight.Portal.Application.DTOs.Authorization;
using VLight.Portal.Application.DTOs.Identity;

namespace VLight.Portal.Application.DTOs.Portal;


/// <summary>
/// 门户首页聚合 DTO
/// 前端首页一次性加载
/// </summary>
public class PortalHomeDto
{
    public UserDto User { get; set; } = default!;


    public IEnumerable<ResourceDto> Menus { get; set; } = Enumerable.Empty<ResourceDto>();


    public PageTemplateDto? HomePage { get; set; }
}
