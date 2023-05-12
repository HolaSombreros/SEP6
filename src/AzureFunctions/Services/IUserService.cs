namespace AzureFunctions.Services; 

public interface IUserService {
    Task<UserDto> RegisterUser(RegisterUserDto registerUserDto);
}