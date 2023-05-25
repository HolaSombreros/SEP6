﻿using MovieManagement.ViewModels.Statistics;

namespace MovieManagement.Pages.Statistics;

public partial class RatingsByGenre : ComponentBase
{
    private RatingsByGenreViewModel? viewModel;

    protected override Task OnInitializedAsync()
    {
        viewModel = new RatingsByGenreViewModel(StatsService, GenreService);
        return viewModel.InitAsync();
    }
}
