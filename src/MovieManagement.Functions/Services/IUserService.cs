namespace MovieManagement.Functions.Services; 

public interface IUserService {
    Task<UserDto> RegisterUser(RegisterUserDto registerUserDto);
}