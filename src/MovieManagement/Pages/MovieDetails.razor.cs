using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MovieManagement.ViewModels;

namespace MovieManagement.Pages;

public partial class MovieDetails : ComponentBase
{
    [Parameter] public int Id { get; set; }
    private MovieDetailsViewModel _movieDetailsViewModel = default!;

    protected override async Task OnInitializedAsync()
    {
        var credits = await MovieService.GetMoviesCreditsAsync(Id);
        _movieDetailsViewModel = new MovieDetailsViewModel(
            movie: await MovieService.GetMovieDetailsAsync(Id),
            cast: credits.MovieCast,
            crew: credits.MovieCrew);
    }

    private string GetGenresToString()
    {
        if (!_movieDetailsViewModel.Genres.Any())
        {
            return "No genres on this movie";
        }

        var genres = "";
        var count = _movieDetailsViewModel.Genres.Count;
        for (var i = 0; i < count - 1; i++)
        {
            genres += $"{_movieDetailsViewModel.Genres[i].Name}, ";
        }

        genres += _movieDetailsViewModel.Genres[count - 1].Name;
        return genres;
    }
    
    async Task ScrollRight(string id)
    {
        await JsRuntime.InvokeVoidAsync("ScrollRight", id, 200);
    }

    async Task ScrollLeft(string id)
    {
        await JsRuntime.InvokeVoidAsync("ScrollLeft", id, 200);
    }
}