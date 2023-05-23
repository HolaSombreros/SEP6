namespace MovieManagement.FunctionDtos;

public class UserDto
{
    public Guid UserId { get; set; }
    public string Username { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;

    public UserDto(UserViewModel userViewModel)
    {
        UserId = userViewModel.UserId;
        Username = userViewModel.Username;
        Email = userViewModel.Email;
        Password = userViewModel.Password;
    }

    [JsonConstructor]
    public UserDto()
    {
    }
}