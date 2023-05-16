namespace MovieManagement.Pages.User;

public partial class Account : ComponentBase
{
    private UserViewModel _userViewModel = default!;
    private string _userIdString = default!;

    protected override async Task OnInitializedAsync()
    {
        _userViewModel = new UserViewModel()
        {
            Username = (await AuthenticationStateProvider.GetAuthenticationStateAsync()).User.FindFirstValue(ClaimTypes.Name),
            Email = (await AuthenticationStateProvider.GetAuthenticationStateAsync()).User.FindFirstValue(ClaimTypes.Email),
        };
        _userIdString = (await AuthenticationStateProvider.GetAuthenticationStateAsync()).User.FindFirstValue("Id");
    }

    private void SaveDetails()
    {
        
    }
}