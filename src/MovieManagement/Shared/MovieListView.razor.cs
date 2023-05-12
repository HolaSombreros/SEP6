﻿using Microsoft.AspNetCore.Components;
using MovieManagement.Models;

namespace MovieManagement.Shared;

public partial class MovieListView : ComponentBase
{
	[Inject]
	public IMovieService MovieService { get; set; } = default!;

	[Parameter]
	public ListType ListType { get; set; } = default!;

	private MovieListViewModel? movieList;

	protected override async Task OnInitializedAsync()
	{
		var data = await MovieService.GetMovieListAsync(ListType, 1);
		movieList = new(data);
	}

	private async Task FetchData()
	{
		var data = await MovieService.GetMovieListAsync(ListType, movieList!.Page + 1);
		movieList.Page = data.Page;
		foreach (var movie in data.Movies)
		{
			movieList.Movies.Add(new MovieViewModel(movie));
		}
	}
}
