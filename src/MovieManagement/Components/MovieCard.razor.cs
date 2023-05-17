using System;

namespace MovieManagement.Components;

public partial class MovieCard : ComponentBase
{
    [Parameter] 
    public MovieViewModel Movie { get; set; } = default!;

    private void ShowMovieDetails(long movieId)
    {
        NavigationManager.NavigateTo($"/movies/{movieId}");
    }
}