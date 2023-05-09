using Microsoft.AspNetCore.Components;
using MovieManagement.Data;
using MovieManagement.Models;

namespace MovieManagement.Pages
{
  public partial class Index : ComponentBase
  {
    private IEnumerable<MovieViewModel>? movies;
    protected override async Task OnInitializedAsync()
    {
      movies = await DummyData.GetMovies();
    }
  }
}
