// ================================
// Contracts / IPortalService.cs
// ================================
using VLight.Portal.Application.DTOs.Portal;


namespace VLight.Portal.Application.Contracts;


public interface IPortalService
{
    Task<PortalHomeDto> GetPortalHomeAsync();
}
