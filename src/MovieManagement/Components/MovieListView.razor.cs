﻿namespace MovieManagement.Components;

public partial class MovieListView : ComponentBase
{
    [Parameter] 
    public ListType ListType { get; set; } = default!;
    private MoviesViewModel? movieList;

    protected override async Task OnInitializedAsync()
    {
        var startPageNumber = 1;
        var data = await MovieService.GetMovieListAsync(ListType, startPageNumber);
        movieList = new(data);
    }

    private async Task FetchDataAsync()
    {
        var nextPageNumber = movieList!.Page + 1;
        if (nextPageNumber <= movieList.TotalPages)
        {
            var data = await MovieService.GetMovieListAsync(ListType, nextPageNumber);
            movieList.Page = data.Page;
            foreach (var movie in data.Movies)
            {
                movieList.Movies.Add(new MovieViewModel(movie));
            }
        }
    }
}
