using Microsoft.AspNetCore.Components;
using MovieManagement.Models;

namespace MovieManagement.Pages;

public partial class Index : ComponentBase
{
	[Inject]
	public IMovieService MovieService { get; set; } = default!;
	private MovieListViewModel? movieList;

	protected override async Task OnInitializedAsync()
	{
		movieList = new(await MovieService.GetUpcomingMoviesAsync());
		//movieList = await DummyData.GetMovies();
	}

	private async Task FetchData()
	{
		Console.WriteLine(movieList.Page);
		//var data = await DummyData.GetMovies();
		//movieList?.Movies.AddRange(data.Movies);
	}
}
