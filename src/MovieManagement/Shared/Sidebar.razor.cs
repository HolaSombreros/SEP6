namespace MovieManagement.Shared;

public partial class Sidebar : ComponentBase
{
    private bool _hideSidebar = true;
    private string? SidebarCssClass => _hideSidebar ? "hide-sidebar" : null;
    private List<MovieListViewModel> _customMovieLists = new();

    protected override void OnInitialized()
    {
        AuthenticationStateProvider.AuthenticationStateChanged += UpdateMovieListsOnAuthAsync;
        MovieListService.OnChanged += UpdateMovieListsOnNotify;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await FetchMovieListsAsync();
        }
    }

    private async void UpdateMovieListsOnAuthAsync(Task<AuthenticationState> authState)
    {
        await FetchMovieListsAsync();
    }

    private async Task FetchMovieListsAsync()
    {
        var userIdentity = (await AuthenticationStateProvider.GetAuthenticationStateAsync()).User.Identity;
        if (userIdentity != null && userIdentity.IsAuthenticated)
        {
            var userId =
                Guid.Parse((await AuthenticationStateProvider.GetAuthenticationStateAsync()).User.FindFirstValue("Id"));
            await MovieListService.GetUserListsAsync(userId);
        }
        else
        {
            _customMovieLists = new();
        }
    }
    
    private void UpdateMovieListsOnNotify(object? obj, EventArgs args)
    {
        _customMovieLists = MovieListService.GetCurrentUserLists();
        StateHasChanged();
    }
    
    private void ToggleSidebar()
    {
        _hideSidebar = !_hideSidebar;
    }
}
