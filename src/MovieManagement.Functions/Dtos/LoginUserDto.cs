namespace MovieManagement.Functions.Dtos; 

public class LoginUserDto {
    [EmailAddress]
    public string Email { get; set; }
    public string Password { get; set; }
}