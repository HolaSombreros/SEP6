namespace MovieManagement.ViewModels.Rating;

public class CreateReviewViewModel
{
    private readonly IRatingService ratingService;
    private readonly IMovieService movieService;
    private readonly int movieId;
    private readonly Guid userGuid;

    public CreateReviewModel CreateReviewModel { get; private set; } = new();
    public string ResultMessage { get; private set; } = string.Empty;

    public CreateReviewViewModel(IRatingService ratingService, IMovieService movieService, int movieId, Guid userGuid)
    {
        this.ratingService = ratingService;
        this.movieService = movieService;
        this.movieId = movieId;
        this.userGuid = userGuid;
    }

    public async Task CreateMovieReviewAsync()
    {
        var movie = await movieService.GetMovieByIdAsync(movieId);

        try { 
            await ratingService.CreateMovieReview(CreateReviewModel, new MovieModel(movie), userGuid);
            ResultMessage = "Rating successfully created!";
            CreateReviewModel = new();
        }
        catch (Exception ex)
        {
            ResultMessage = ex.Message;
            throw;
        }
    }
}
