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
    
    public async Task<UserViewModel> LoginUserAsync(UserViewModel user)
    {
        var newUser = new RegisterUserDto(user);
        var userDto = await _service.PostAsync<UserDto>(_settings.LoginUserPath, newUser);
        user.UserId = userDto.UserId;
        user.Username = userDto.Username;
        return user;
    }

    public async Task<UserViewModel> EditUserAsync(UserViewModel user)
    {
        var newUser = new UserDto(user);
        var userDto = await _service.PutAsync<UserDto>(_settings.UpdateUserPath, newUser);
        user.Username = userDto.Username;
        user.Email = userDto.Email;
        user.Password = userDto.Password;
        return user;
    }
    
    public async Task DeleteUserAsync(Guid userId)
    {
        await _service.DeleteFromRouteAsync(_settings.DeleteUserPath, userId.ToString());
    }
}