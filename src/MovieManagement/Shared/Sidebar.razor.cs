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
        var user = (await AuthenticationStateProvider.GetAuthenticationStateAsync()).User;
        if (user.Identity is {IsAuthenticated: true})
        {
            var userId = Guid.Parse(user.FindFirstValue("Id"));
            await MovieListService.GetUserListsAsync(userId);
        }
        else
        {
            _customMovieLists = new List<MovieListViewModel>();
        }
    }
    
    private void UpdateMovieListsOnNotify()
    {
        _customMovieLists = MovieListService.GetCurrentUserLists();
        StateHasChanged();
    }
    
    private void ToggleSidebar()
    {
        _hideSidebar = !_hideSidebar;
    }

    private async Task ShowDeleteListModal(MovieListViewModel list)
    {
        var modalParameters = new ModalParameters().Add(nameof(DeleteMovieList.ListId), list.Id);
        var modal = Modal.Show<DeleteMovieList>($"Remove {list.Title}?", modalParameters);
        await modal.Result;
        modal.Close();
    }
}
