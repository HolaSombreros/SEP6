
namespace MovieManagement.Domain.Models;

public class User
{
    public Guid UserId { get; set; }
    public string Username { get; set; } = default!;
    [EmailAddress]
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}