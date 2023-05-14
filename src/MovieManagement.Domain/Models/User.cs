
namespace MovieManagement.Domain.Models;

public class User
{
    public string Username { get; set; } = default!;
    public Guid UserId { get; set; }
    [EmailAddress]
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}