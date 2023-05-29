namespace MovieManagement.Pages.Statistics;

public partial class GenderDistributionByGenre : ComponentBase
{
    private GenderByGenreViewModel _viewModel = null!;
    private List<Genre> _genres = default!;

    protected override async Task OnInitializedAsync()
    {
        var genres = await GenreService.GetAllGenresAsync()!;
        _genres = new List<Genre>();
        foreach (var genre in genres.Genres!)
        {
            _genres.Add(genre!);
        }
        var data = await StatsService.GetGenderDistributionAsync(0);
        _viewModel = new GenderByGenreViewModel(data);
        StateHasChanged();
    }
    
    private async Task GetGenderDistributionsAsync(ChangeEventArgs args)
    {
        try
        {
            var genreId = int.Parse(args.Value!.ToString()!);
            var data = await StatsService.GetGenderDistributionAsync(genreId);
            _viewModel = new GenderByGenreViewModel(data);
        }
        catch
        {
            _viewModel = null!;
        }
        StateHasChanged();
    }
}
