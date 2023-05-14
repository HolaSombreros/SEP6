namespace MovieManagement.Services;

public class UserService : IUserService
{
    private readonly IAzureService _service;
    private readonly AzureFunctionsConfig _settings;

    public UserService(IAzureService service, IOptions<AzureFunctionsConfig> settings)
    {
        _service = service;
        _settings = settings.Value;
    }
    
    public async Task<UserViewModel> RegisterUserAsync(UserViewModel user)
    {
        var newUser = new RegisterUserDto(user);
        var userDto = await _service.PostAsync<UserDto>(_settings.RegisterUserPath, newUser);
        user.UserId = userDto.UserId;
        return user;
    }
}