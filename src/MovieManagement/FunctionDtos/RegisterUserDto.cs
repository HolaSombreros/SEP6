namespace MovieManagement.FunctionDtos;

public class RegisterUserDto
{
    public string Username { get; } = default!;
    public string Email { get; } = default!;
    public string Password { get; } = default!;

    public RegisterUserDto(UserViewModel user)
    {
        Username = user.Username;
        Email = user.Email;
        Password = user.Password;
    }

    [JsonConstructor]
    public RegisterUserDto()
    {
    }
}