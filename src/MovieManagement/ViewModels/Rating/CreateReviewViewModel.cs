using MovieManagement.Attributes;

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

public class CreateReviewModel {
    [Required(ErrorMessage = "A rating is required")]
    [Range(1, 10, ErrorMessage = "A rating must be between {1} and {2}")]
    public int Rating { get; set; }

    [OptionalStringLength(500, MinimumLength = 3, ErrorMessage = "If present, a review must be between {2} and {1} characters")]
    public string? Review { get; set; }
}

public class MovieModel
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string? PosterUrl { get; set; }
    public DateOnly? ReleaseDate { get; set; }

    public MovieModel(Movie movie)
    {
        Id = movie.Id;
        Title = movie.Title;
        PosterUrl = movie.ImageUrl;
        ReleaseDate = DateOnly.FromDateTime(movie.ReleaseDate);
    }
}