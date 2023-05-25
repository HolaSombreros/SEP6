namespace MovieManagement.Pages.Statistics;

public partial class HighestRevenueMovies : ComponentBase
{
    private MoviesViewModel _list = default!;
    private int _year;

    protected override async Task OnInitializedAsync()
    {
        var data = await GetMovieListAsync(_year, 1);
        _list = new(data);
    }

    private async Task FetchDataAsync()
    {
        var nextPageNumber = _list.Page + 1;
        if (nextPageNumber <= _list.TotalPages)
        {
            var data = await GetMovieListAsync(_year, nextPageNumber);
            _list.Page = data.Page;
            foreach (var movie in data.Movies)
            {
                _list.Movies.Add(new MovieViewModel(movie));
            }
        }
    }

    private async Task OnYearChanged(ChangeEventArgs e)
    {
        _year = Int32.Parse(e.Value?.ToString() ?? "0");
        var data = await GetMovieListAsync(_year, 1);
        _list = new MoviesViewModel(data);
        StateHasChanged();
    }

    private Task<MovieList> GetMovieListAsync(int year, int page)
    {
        return CombinedRatingService.GetMoviesWithHighestRevenue(year, page);
    }
}