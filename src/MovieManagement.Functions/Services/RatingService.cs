namespace MovieManagement.Functions.Services;

public class RatingService : IRatingService
{
    private readonly IRatingRepository _repository;

    public RatingService(IRatingRepository repository)
    {
        _repository = repository;
    }

    public Task<RatingDto> PutRating(RatingDto rating)
    {
        throw new NotImplementedException();
    }

    public Task<RatingDto> GetMovieUserRating(int movieId, Guid userId)
    {
        throw new NotImplementedException();
    }
}