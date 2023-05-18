namespace MovieManagement.Pages.User;

public partial class Account : ComponentBase
{
    private UserViewModel _userViewModel = default!;
    private string _userIdString = default!;
    private string _successMessage = default!;
    private string _errorMessage = default!;

    protected override async Task OnInitializedAsync()
    {
        _userViewModel = new UserViewModel()
        {
            UserId = Guid.Parse((await AuthenticationStateProvider.GetAuthenticationStateAsync()).User.FindFirstValue("Id")),
            Username = (await AuthenticationStateProvider.GetAuthenticationStateAsync()).User.FindFirstValue(ClaimTypes.Name),
            Email = (await AuthenticationStateProvider.GetAuthenticationStateAsync()).User.FindFirstValue(ClaimTypes.Email),
            Password = "Placeholder",
            ConfirmPassword = "Placeholder"
        };
        _userIdString = _userViewModel.UserId.ToString();
    }

    private async Task SaveDetailsAsync()
    {
        try
        {
            if (!string.IsNullOrEmpty(_userViewModel.EditPassword))
            {
                _userViewModel.Password = _userViewModel.EditPassword;
                _userViewModel.ConfirmPassword = _userViewModel.EditConfirmPassword;
            }
            else
            {
                _userViewModel.Password = string.Empty;
                _userViewModel.ConfirmPassword = string.Empty;
            }
            _userViewModel = await UserService.EditUserAsync(_userViewModel);
            await ((MovieManagementASP) AuthenticationStateProvider).LogoutAsync();
            await ((MovieManagementASP) AuthenticationStateProvider).LoginAsync(_userViewModel);
            SetSuccessMessage("The account has been successfully updated");
        }
        catch (Exception exception)
        {
            SetErrorMessage(exception.Message);
        }
    }

    private void SetErrorMessage(string message)
    {
        _successMessage = "";
        _errorMessage = message;
    }
    
    private void SetSuccessMessage(string message)
    {
        _errorMessage = "";
        _successMessage = message;
    }
}