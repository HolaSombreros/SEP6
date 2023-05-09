using Microsoft.AspNetCore.Components;
using MovieManagement.Data;
using MovieManagement.Models;

namespace MovieManagement.Pages;

public partial class Index : ComponentBase
{
	[Inject]
	public IMovieService MovieService { get; set; } = default!;
	private MovieListViewModel? movieList;

	protected override async Task OnInitializedAsync()
	{
		//movieList = new(await MovieService.GetUpcomingMoviesAsync());
		movieList = await DummyData.GetMovies();
	}

	private async Task FetchMovies()
	{
		Console.WriteLine("Current: " + movieList.Movies.Count);
		var movies = await DummyData.GetMovies();
		movieList.Movies.AddRange(movies.Movies);
		Console.WriteLine("New: " + movieList.Movies.Count);
	}
}
