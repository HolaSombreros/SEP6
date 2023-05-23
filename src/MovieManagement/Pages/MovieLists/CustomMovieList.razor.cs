namespace MovieManagement.Pages.MovieLists;

public partial class CustomMovieList : ComponentBase
{
    [Parameter]
    public string Id { get; set; } = string.Empty;

    private MovieListViewModel _list = default!;

    protected override void OnInitialized()
    {
        _list = MovieListService.GetCustomList(Guid.Parse(Id));
        MovieListService.OnChanged += UpdateMovieListOnNotify;
    }

    private void UpdateMovieListOnNotify(object? obj, EventArgs args)
    {
        _list = MovieListService.GetCustomList(Guid.Parse(Id));
    }

    private async Task RemoveFromList(MovieViewModel movie)
    {
        await MovieListService.DeleteMovieFromListAsync(_list.Id, movie);
    }
}