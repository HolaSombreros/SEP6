namespace MovieManagement.ViewModels.Rating;

public class DeleteReviewViewModel
{
    private readonly IRatingService ratingService;

    public string ErrorMessage { get; private set; } = "";

    public DeleteReviewViewModel(IRatingService ratingService)
    {
        this.ratingService = ratingService;
    }

    public async Task<bool> DeleteReviewAsync(Guid reviewId)
    {
        ErrorMessage = "";

        try
        {
            await ratingService.DeleteMovieReviewAsync(reviewId);
            return true;
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
            return false;
        }
    }
}
