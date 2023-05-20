namespace MovieManagement.Components.Reviews;

public partial class ReviewsView : ComponentBase
{
    [Inject]
    public AuthenticationStateProvider AuthenticationStateProvider { get; set; } = default!;

    [Inject]
    public IRatingService RatingService { get; set; } = default!;

    [Parameter]
    public int MovieId { get; set; }

    private ReviewsViewModel viewModel = default!;

    protected override async Task OnInitializedAsync()
    {
        var userIdAsString = (await AuthenticationStateProvider.GetAuthenticationStateAsync()).User.FindFirstValue("Id");
        viewModel = Guid.TryParse(userIdAsString, out var userIdAsGuid)
            ? (new(RatingService, MovieId, userIdAsGuid))
            : (new(RatingService, MovieId, null));

        await GetMovieReviews();
    }

    private Task GetMovieReviews()
    {
        return viewModel.GetMovieReviewsAsync();
    }
}
