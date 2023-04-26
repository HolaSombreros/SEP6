using Microsoft.AspNetCore.Components;
using MovieManagement.Models;

namespace MovieManagement.Shared;

public partial class MovieCard : ComponentBase
{
	[Parameter]
	public Movie Movie { get; set; } = default!;

	protected override void OnInitialized()
	{
		Movie.PosterPath = "https://image.tmdb.org/t/p/w500" + Movie.PosterPath;
	}
}
