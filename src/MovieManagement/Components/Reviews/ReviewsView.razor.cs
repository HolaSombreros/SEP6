namespace MovieManagement.Components.Reviews;

public partial class ReviewsView : ComponentBase
{
    [Parameter]
    public int MovieId { get; set; }

    private ReviewsViewModel viewModel = default!;

    protected override async Task OnInitializedAsync()
    {
        var userIdAsString = (await AuthenticationStateProvider.GetAuthenticationStateAsync()).User.FindFirstValue("Id");
        viewModel = Guid.TryParse(userIdAsString, out var userIdAsGuid)
            ? (new(RatingService, MovieId, userIdAsGuid))
            : (new(RatingService, MovieId, null));

        var startPage = 1;
        await GetMovieReviewsAsync(startPage);
    }

    private Task FetchDataAsync()
    {
        var nextPage = viewModel.PaginatedReviews!.Page + 1;
        return nextPage <= viewModel.PaginatedReviews.TotalPages ? GetMovieReviewsAsync(nextPage) : Task.CompletedTask;
    }

    private Task GetMovieReviewsAsync(int page)
    {
        return viewModel.GetMovieReviewsAsync(page);
    }

    private void RemoveReviewHandler(Guid reviewId)
    {
        viewModel.RemoveReview(reviewId);
    }
}
