namespace MovieManagement.Components.Reviews;

public partial class CreateReviewView : ComponentBase
{
    [Parameter]
    public int MovieId { get; set; }

    private CreateReviewViewModel viewModel = default!;

    protected override async Task OnInitializedAsync()
    {
        if (Guid.TryParse((await AuthenticationStateProvider.GetAuthenticationStateAsync()).User.FindFirstValue("Id"), out var userGuid))
        {
            viewModel = new(RatingService, MovieService, MovieId, userGuid);
        }
    }

    private void RatingChanged(int rating)
    {
        viewModel.CreateReviewModel.Rating = rating;
    }
}
