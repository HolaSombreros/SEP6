namespace MovieManagement.Functions.Services; 

public interface IUserService {
    Task<UserDto> RegisterUserAsync(RegisterUserDto registerUserDto);
    Task<UserDto> GetUserAsync(LoginUserDto loginUserDto);
    Task<UserDto> UpdateUserAsync(UserDto userDto);
    Task DeleteUserAsync(Guid userId);
}