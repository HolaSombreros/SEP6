namespace MovieManagement.Functions.Services; 

public interface IUserService {
    Task<UserDto> RegisterUser(RegisterUserDto registerUserDto);
    Task<UserDto> GetUser(LoginUserDto loginUserDto);
    Task<UserDto> UpdateUser(UserDto userDto);
    Task DeleteUser(Guid userId);
    Task<IList<UserDto>> GetUsers(IList<Guid> ids);
}