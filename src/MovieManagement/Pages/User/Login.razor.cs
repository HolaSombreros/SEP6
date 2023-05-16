namespace MovieManagement.Pages.User;

public partial class Login : ComponentBase
{
    private string _errorMessage = default!;
    private UserViewModel _userViewModel = default!;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        _userViewModel = new UserViewModel();
    }

    private async Task LoginAsync()
    {
        try {
            await ((MovieManagementASP) AuthenticationStateProvider).LoginAsync(_userViewModel);
            NavigationManager.NavigateTo("/");
        }
        catch (Exception e) {
            _errorMessage = e.Message;
        }
    }
}
