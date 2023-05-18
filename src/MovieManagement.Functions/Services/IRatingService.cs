namespace MovieManagement.Functions.Services;

public interface IRatingService
{
    Task<RatingDto> PutRating(RatingDto rating);
    Task<RatingDto> AddRating(RatingDto ratingDto);
    Task<IList<RatingQueryDto>> GetMovieRatings(IList<int> ratingList);
    Task DeleteRating(Guid ratingId);
    Task<RatingDto> GetRatingById(Guid ratingId);
    Task<RatingDto> GetMovieRatingByUser(int movieId, Guid userId);
}