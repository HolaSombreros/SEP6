namespace MovieManagement.Pages.MovieLists;

public partial class CustomMovieList : ComponentBase, IDisposable
{
    [Parameter]
    public string Id { get; set; } = string.Empty;
    private string currentId { get; set; } = string.Empty;

    private MovieListViewModel _list = default!;

    protected override void OnInitialized()
    {
        _list = MovieListService.GetCustomList(Guid.Parse(Id));
        MovieListService.OnChanged += UpdateMovieListOnNotify;
    }

    protected override void OnAfterRender(bool firstRender)
    {
        _list = MovieListService.GetCustomList(Guid.Parse(Id));
        if (!_list.Id.ToString().Equals(currentId))
        {
            currentId = _list.Id.ToString();
            StateHasChanged();
        }
    }

    private void UpdateMovieListOnNotify()
    {
        _list = MovieListService.GetCustomList(Guid.Parse(Id));
    }

    private async Task RemoveFromList(MovieViewModel movie)
    {
        await MovieListService.DeleteMovieFromListAsync(_list.Id, movie);
    }

    public void Dispose()
    {
        MovieListService.OnChanged -= UpdateMovieListOnNotify;
    }
}