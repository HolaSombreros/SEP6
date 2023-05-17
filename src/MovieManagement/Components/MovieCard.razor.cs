using System;

namespace MovieManagement.Components;

public partial class MovieCard : ComponentBase
{
    [Parameter] 
    public MovieViewModel Movie { get; set; } = default!;

// TODO:
// Call function with IDs of movies as payload
// Function returns average rating for all movies + vote count for each
// Do math to combine our average with TMDB average? 

    private void ShowMovieDetails(long movieId)
    {
        NavigationManager.NavigateTo($"/movies/{movieId}");
    }
}