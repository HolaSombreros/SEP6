
namespace MovieManagement.Domain.Models;

public class User
{
    public string? Username { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    public string? Password { get; set; }
}