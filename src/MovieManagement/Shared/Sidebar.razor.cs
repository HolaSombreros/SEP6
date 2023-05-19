namespace MovieManagement.Shared;

public partial class Sidebar : ComponentBase
{
    private bool hideSidebar = true;
    private string? SidebarCssClass => hideSidebar ? "hide-sidebar" : null;
    private List<MovieListViewModel>? customMovieLists;

    protected override void OnInitialized()
    {
        customMovieLists = DummyData.GetCustomMovieLists();
        // TODO - Implement me.
    }

    private void ToggleSidebar()
    {
        hideSidebar = !hideSidebar;
    }

    private void CreateNewMovieList()
    {
        // TODO - Implement me.
    }
}
