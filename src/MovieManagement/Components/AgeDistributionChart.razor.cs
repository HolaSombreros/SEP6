namespace MovieManagement.Components;

public partial class AgeDistributionChart : ComponentBase
{
    [Parameter]
    public int MovieId { get; set; }
    private AgeDistributionViewModel _viewModel = null!;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            var data = await StatsService.GetAgeDistributionAsync(MovieId);
            _viewModel = new AgeDistributionViewModel(data);
        }
        catch (Exception)
        {
            _viewModel = default!;
        }
    }
}