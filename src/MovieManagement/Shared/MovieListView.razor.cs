using Microsoft.AspNetCore.Components;
using MovieManagement.Models.Index;

namespace MovieManagement.Shared;

public partial class MovieListView : ComponentBase
{
  [Inject]
  public IMovieService MovieService { get; set; } = default!;

  [Parameter]
  public ListType ListType { get; set; } = default!;
  private MoviesViewModel? movieList;

  protected override async Task OnInitializedAsync()
  {
    var startPageNumber = 1;
    var data = await MovieService.GetMovieListAsync(ListType, startPageNumber);
    movieList = new(data);
  }

  private async Task FetchData()
  {
    var nextPageNumber = movieList!.Page + 1;
    var data = await MovieService.GetMovieListAsync(ListType, nextPageNumber);
    movieList.Page = data.Page;
    foreach (var movie in data.Movies)
    {
      movieList.Movies.Add(new MovieViewModel(movie));
    }
  }
}
