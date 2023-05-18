namespace MovieManagement.Functions.Services;

public interface IRatingService
{
    Task<RatingDto> PutRating(RatingDto rating);
    Task<RatingDto> AddRating(RatingDto ratingDto);
    Task<IList<RatingQueryDto>> GetMovieRatings(IList<int> ratingList);
}