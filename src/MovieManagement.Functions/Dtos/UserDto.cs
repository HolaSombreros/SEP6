namespace MovieManagement.Functions.Dtos; 

public class UserDto {
    
    public Guid UserId { get; set; }

    public string Username { get; set; } = default!;

    public string Email { get; set; } = default!;

    public string Password { get; set; } = default!;
}