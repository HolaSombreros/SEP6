namespace MovieManagement.Components.MovieLists;

public partial class AddMovieToList : ComponentBase
{
    [Parameter] 
    public MovieViewModel Movie { get; set; } = default!;

    private List<MovieListViewModel> _lists = default!;

    protected override void OnInitialized()
    {
        _lists = MovieListService.GetCurrentUserLists();
        SetHasMovieOnLists();
        MovieListService.OnChanged += UpdateMovieListOnNotify;
    }

    private void UpdateMovieListOnNotify(object? obj, EventArgs args)
    {
        _lists = MovieListService.GetCurrentUserLists();
        SetHasMovieOnLists();
    }

    private void SetHasMovieOnLists()
    {
        foreach (var list in _lists)
        {
            list.HasMovie = list.Movies.Any(movie => movie.Id == Movie.Id);
        }
    }

    private async Task AddRemoveMovieAsync(Guid listId, bool addMovie)
    {
        if (addMovie)
        {
            await MovieListService.AddMovieToListAsync(listId, Movie);
        }
        else
        {
            await MovieListService.DeleteMovieFromListAsync(listId, Movie);
        }
    }
}