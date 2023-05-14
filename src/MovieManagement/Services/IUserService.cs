namespace MovieManagement.Services;

public interface IUserService
{
    Task<UserViewModel> RegisterUserAsync(UserViewModel user);
}