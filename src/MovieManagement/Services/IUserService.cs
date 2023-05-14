namespace MovieManagement.Services;

public interface IUserService
{
    Task<UserViewModel> RegisterUserAsync(UserViewModel user);
    Task<UserViewModel> LoginUserAsync(UserViewModel user);
    Task<UserViewModel> EditUserAsync(UserViewModel user);
}