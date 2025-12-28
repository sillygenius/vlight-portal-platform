// ================================
// Contracts / IUserService.cs
// ================================
using VLight.Portal.Application.DTOs.Identity;


namespace VLight.Portal.Application.Contracts;


public interface IUserService
{
    Task<UserDto> GetCurrentUserAsync();
}
