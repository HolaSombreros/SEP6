namespace MovieManagement.FunctionDtos;

public class AddRatingDto
{
    public MovieDto MovieDto { get; }
    public int Rating { get; }
    public string? Review { get; }
    public Guid UserId { get; }

    public AddRatingDto(RatingViewModel ratingViewModel, MovieDetailsViewModel movieDetailsViewModel, Guid userId)
    {
        MovieDto = new MovieDto(movieDetailsViewModel);
        Rating = ratingViewModel.StarRating;
        Review = ratingViewModel.Review;
        UserId = userId;
    }

    [JsonConstructor]
    public AddRatingDto()
    {
    }
}
