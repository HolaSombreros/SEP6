namespace MovieManagement.Pages.User;

public partial class RegisterAccount : ComponentBase
{
    private string _errorMessage = default!;
    private UserViewModel _userViewModel = default!;

    protected override void OnInitialized()
    {
        base.OnInitialized();        
        _userViewModel = new UserViewModel();
    }

    private async Task RegisterAsync() {
        try
        {
            TrimUser();
            if (_userViewModel.Email.Contains(' ') ||
                _userViewModel.Username.Contains(' ') ||
                _userViewModel.Password.Contains(' '))
            {
                throw new Exception("No empty spaces allowed in username, email or password");
            }

            await UserService.RegisterUserAsync(_userViewModel);
            NavigationManager.NavigateTo("/Login");
        }
        catch (Exception e) {
            _errorMessage = e.Message;
        }
    }

    private void TrimUser()
    {
        _userViewModel.Email = _userViewModel.Email.Trim();
        _userViewModel.Username = _userViewModel.Username.Trim();
    }
}