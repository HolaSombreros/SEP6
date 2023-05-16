namespace MovieManagement.FunctionDtos; 

public class UserDto {
    
    public Guid UserId { get; set; } = default!;

    public string Username { get; set; } = default!;

    public string Email { get; set; } = default!;

    public string Password { get; set; } = default!;
}