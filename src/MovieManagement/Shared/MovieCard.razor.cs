using Microsoft.AspNetCore.Components;
using MovieManagement.Models.Index;

namespace MovieManagement.Shared;

public partial class MovieCard : ComponentBase
{
  [Parameter]
  public MovieViewModel Movie { get; set; } = default!;

  [Inject]
  public NavigationManager NavigationManager { get; set; } = default!;

  protected override void OnInitialized()
  {
    Movie.PosterPath = "https://image.tmdb.org/t/p/w500" + Movie.PosterPath;
  }

  private void ShowMovieDetails(long movieId)
  {
    NavigationManager.NavigateTo($"/movies/all/{movieId}");
  }
}
