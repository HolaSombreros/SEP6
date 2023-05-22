namespace MovieManagement.FunctionDtos;

public class CreateReviewDto
{
    public MovieDto MovieDto { get; }
    public int Rating { get; }
    public string? Review { get; }
    public Guid UserId { get; }

    public CreateReviewDto(CreateReviewModel reviewModel, MovieModel movieModel, Guid userId)
    {
        MovieDto = new MovieDto(movieModel);
        Rating = reviewModel.Rating;
        Review = reviewModel.Review;
        UserId = userId;
    }
}
