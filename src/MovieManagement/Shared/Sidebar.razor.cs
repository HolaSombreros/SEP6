using Microsoft.AspNetCore.Components;

namespace MovieManagement.Shared;

public partial class Sidebar : ComponentBase
{
    private bool hideSidebar = true;

    private string? SidebarCssClass => hideSidebar ? "hide-sidebar" : null;

    private void ToggleSidebar()
    {
        hideSidebar = !hideSidebar;
    }
}