namespace MovieManagement.Shared;

public partial class NavMenu
{
    private bool hideMenu = true;

    private string? NavMenuCssClass => hideMenu ? "hideMenu" : null;

    private void ToggleNavMenu()
    {
        hideMenu = !hideMenu;
    }
}
