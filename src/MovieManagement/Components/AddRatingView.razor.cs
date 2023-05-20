namespace MovieManagement.Components;

public partial class AddRatingView : ComponentBase
{
    [Parameter]
    public MovieDetailsViewModel MovieDetailsViewModel { get; set; } = default!;

    [Parameter]
    public int MovieId { get; set; }

    private RatingViewModel ratingViewModel = new();
    private Guid userId = default!;
    private string resultMessage = string.Empty;
    private string resultCssClass = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        var loggedInUserId = (await AuthenticationStateProvider.GetAuthenticationStateAsync()).User.FindFirstValue("Id");
        if (loggedInUserId != null)
        {
            userId = Guid.Parse(loggedInUserId);
        }
    }

    private void SetRating(int rating)
    {
        ratingViewModel.StarRating = rating;
    }

    private async Task RateMovieAsync()
    {
        resultMessage = "";
        try
        {
            var rating = await RatingService.RateMovieAsync(ratingViewModel, MovieDetailsViewModel, userId);
            ratingViewModel = new();
            resultMessage = "Review successfully added!";
            resultCssClass = "success-message";
            // TODO - Do something with this rating to have it added to list of reviews? Might be unnecessarily complicated...
        }
        catch (Exception ex)
        {
            resultMessage = ex.Message;
            resultCssClass = "error-message";
        }
    }

    private string IsActive(int rating)
    {
        return rating <= ratingViewModel.StarRating ? "active" : "";
    }
}