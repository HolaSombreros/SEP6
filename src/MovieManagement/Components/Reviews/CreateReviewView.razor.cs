namespace MovieManagement.Components.Reviews;

public partial class CreateReviewView : ComponentBase
{
    [Parameter]
    public int MovieId { get; set; }

    private CreateReviewViewModel viewModel = default!;
    private string resultCssClass = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        if (Guid.TryParse((await AuthenticationStateProvider.GetAuthenticationStateAsync()).User.FindFirstValue("Id"), out var userGuid))
        {
            viewModel = new(RatingService, MovieService, MovieId, userGuid);
        }
    }

    private async Task CreateMovieReviewAsync()
    {
        try
        {
            await viewModel!.CreateMovieReviewAsync();
            resultCssClass = "success-message";
        }
        catch (Exception)
        {
            resultCssClass = "error-message";
        }
    }

    private void RatingChanged(int rating)
    {
        viewModel.CreateReviewModel.Rating = rating;
    }
}
