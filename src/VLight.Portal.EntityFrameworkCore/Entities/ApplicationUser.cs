// Entities/ApplicationUser.cs
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationUser : IdentityUser
{
    public string DisplayName { get; set; }
}


