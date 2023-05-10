using Microsoft.AspNetCore.Components;
using MovieManagement.ViewModels;

namespace MovieManagement.Pages;

public partial class MovieDetails
{
    [Parameter]
    public int Id { get; set; }
    private MovieDetailsViewModel _movieDetailsViewModel = default!;

    protected override async Task OnInitializedAsync()
    {
        _movieDetailsViewModel = new MovieDetailsViewModel(await MovieService.GetMovieDetailsAsync(Id));
    }
}