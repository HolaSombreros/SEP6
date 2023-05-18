namespace MovieManagement.Shared;

public partial class NavMenu : ComponentBase
{
  private bool _hideMenu = true;
  private string? NavMenuCssClass => _hideMenu ? "hide-menu" : null;

    private void ToggleNavMenu()
    {
        _hideMenu = !_hideMenu;
    }
    
    private async Task LogoutAsync()
    {
        await ((MovieManagementASP) AuthenticationStateProvider).LogoutAsync();
    }

    private void GoHome()
    {
        NavigationManager.NavigateTo("/");
    }
}
