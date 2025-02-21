using Microsoft.AspNetCore.Identity;

namespace PetAdoptionAPI.Models;

public class User : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? PasswordHash { get; set; } //nullable for social logins
    public AuthProvider Provider { get; set; }
    public string? ProviderID { get; set; }  // ID from Google/Facebook if social login

    public UserRole Role { get; set; } = UserRole.NormalUser;

    public ICollection<AdoptionRequest> AdoptionRequests { get; set; } = null!;
}

public enum AuthProvider 
{
    Local,
    Google,
    Facebook
}

public enum UserRole
{
    NormalUser,
    PetShelterAdmin
}