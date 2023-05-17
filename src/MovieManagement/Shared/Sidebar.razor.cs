using MovieManagement.ViewModels.Search;

namespace MovieManagement.Shared;

public partial class Sidebar : ComponentBase
{
    private bool hideSidebar = true;
    private string? SidebarCssClass => hideSidebar ? "hide-sidebar" : null;
    private List<MovieListViewModel>? customMovieLists;
    private SearchViewModel searchModel = new();

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

    private async Task SearchAsync()
    {
        // TODO: Call SearchService.
        searchModel = new();
    }
}
