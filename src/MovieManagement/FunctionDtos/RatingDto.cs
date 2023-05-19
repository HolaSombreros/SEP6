namespace MovieManagement.FunctionDtos;

public class RatingDto
{
    public MovieDto MovieDto { get; }
    public int Rating { get; }
    public string? Review { get; }
    public Guid UserId { get; }

    public RatingDto(RatingViewModel ratingViewModel, MovieDetailsViewModel movieViewModel, Guid userId)
    {
        MovieDto = new MovieDto(movieViewModel);
        Rating = ratingViewModel.StarRating;
        Review = ratingViewModel.Review;
        UserId = userId;
    }

    [JsonConstructor]
    public RatingDto()
    {
    }
}
