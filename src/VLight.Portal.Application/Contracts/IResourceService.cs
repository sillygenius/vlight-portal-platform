// ================================
// Contracts / IResourceService.cs
// ================================
using VLight.Portal.Application.DTOs.Authorization;


namespace VLight.Portal.Application.Contracts;


public interface IResourceService
{
    Task<IEnumerable<ResourceDto>> GetUserResourcesAsync();
}
