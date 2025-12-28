// ================================
// Services / UserService.cs
// ================================
using Microsoft.EntityFrameworkCore;
using VLight.Portal.Application.Contracts;
using VLight.Portal.Application.DTOs.Identity;
using VLight.Portal.EntityFrameworkCore.DbContexts;


namespace VLight.Portal.Application.Services;


/// <summary>
/// 用户应用服务
/// </summary>
public class UserService : IUserService
{
    private readonly PortalDbContext _db;
    private readonly ICurrentUser _currentUser;


    public UserService(PortalDbContext db, ICurrentUser currentUser)
    {
        _db = db;
        _currentUser = currentUser;
    }


    public async Task<UserDto> GetCurrentUserAsync()
    {
        var user = await _db.Users
        .Include(u => u.Department)
        .FirstAsync(u => u.Id == _currentUser.UserId);


        return new UserDto(
        user.Id,
        user.UserName!,
        user.DisplayName,
        user.Department?.Name
        );
    }
}
