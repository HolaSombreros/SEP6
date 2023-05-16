namespace MovieManagement.Database.Repositories;

public interface IRatingRepository
{
    Task<RatingEntity?> GetMovieUserRating(int movieId, Guid userId); 

}