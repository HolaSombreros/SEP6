namespace MovieManagement.Shared;

public partial class NavMenu
{
    private bool hideMenu = true;

    private string? NavMenuCssClass => hideMenu ? "hide-menu" : null;

    private void ToggleNavMenu()
    {
        hideMenu = !hideMenu;
    }
}
