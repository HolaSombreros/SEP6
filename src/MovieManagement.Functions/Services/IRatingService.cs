namespace MovieManagement.Functions.Services;

public interface IRatingService
{
    Task<MovieRatingDto> PutRatingAsync(MovieRatingDto rating);
    Task<MovieRatingDto> AddRatingAsync(MovieRatingDto ratingDto);
    Task<IList<RatingQueryDto>> GetMovieRatingsAsync(IList<int> ratingList);
    Task DeleteRatingAsync(Guid ratingId);
    Task<MovieRatingDto> GetRatingByIdAsync(Guid ratingId);
    Task<MovieRatingDto> GetMovieRatingByUserAsync(int movieId, Guid userId);
    Task<RatingResultDto> GetMovieRatingsAsync(GetRatingDto ratingDto, int pageNumber);
}