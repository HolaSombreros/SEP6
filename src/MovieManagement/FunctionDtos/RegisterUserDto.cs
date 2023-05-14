namespace MovieManagement.FunctionDtos;

public class RegisterUserDto
{
    public string Username { get; }
    public string Email { get; }
    public string Password { get; }

    public RegisterUserDto(UserViewModel user)
    {
        Username = user.Username;
        Email = user.Email;
        Password = user.Password;
    }
}