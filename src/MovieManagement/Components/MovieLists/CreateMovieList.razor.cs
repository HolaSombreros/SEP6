namespace MovieManagement.Components.MovieLists;

public partial class CreateMovieList : ComponentBase
{
    private MovieListViewModel _list = default!;
    private string _errorMessage = default!;
    private string _successMessage = default!;

    protected override async Task OnInitializedAsync()
    {
        _list = new MovieListViewModel()
        {
            UserId = Guid.Parse((await AuthenticationStateProvider.GetAuthenticationStateAsync()).User.FindFirstValue("Id"))
        };
    }

    private async Task CreateNewListAsync()
    {
        try
        {
            await MovieListService.CreateCustomListAsync(_list);
            _successMessage = "The new list has been successfully added";
            await OnInitializedAsync();
        }
        catch (Exception e)
        {
            _errorMessage = e.Message;
        }
    }
}