namespace MovieManagement.Components.Reviews;

public partial class ReviewsView : ComponentBase, IDisposable
{
    [Parameter]
    public int MovieId { get; set; }

    private ReviewsViewModel viewModel = default!;

    private bool CanDeleteReview(Guid reviewId) => reviewId == userReviewId;
    private Guid? userReviewId;

    protected override async Task OnInitializedAsync()
    {
        var userIdAsString = (await AuthenticationStateProvider.GetAuthenticationStateAsync()).User.FindFirstValue("Id");
        viewModel = Guid.TryParse(userIdAsString, out var userIdAsGuid)
            ? (new(RatingService, MovieId, userIdAsGuid))
            : (new(RatingService, MovieId, null));

        if (userIdAsGuid != Guid.Empty)
        {
            var usersMovieReview = await viewModel.GetLoggedInUserReviewAsync();
            if (usersMovieReview != null)
            {
                userReviewId = usersMovieReview.Id;
            }
        }

        var startPage = 1;
        await GetMovieReviewsAsync(startPage);

        viewModel.OnReviewCreated += StateHasChanged;
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

    public void Dispose()
    {
        viewModel.OnReviewCreated -= StateHasChanged;
        viewModel?.Dispose();
    }
}
