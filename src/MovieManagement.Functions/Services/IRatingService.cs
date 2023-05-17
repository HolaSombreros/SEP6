namespace MovieManagement.Functions.Services;

public interface IRatingService
{
    Task<RatingDto> PutRating(RatingDto rating);
    //Task<RatingDto?> GetMovieUserRating(int movieId, Guid userId); 
}