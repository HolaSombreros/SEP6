namespace MovieManagement.Functions.Services;

public class RatingService : IRatingService
{
    private readonly IMapper _mapper;
    private readonly IRatingRepository _repository;

    public RatingService(IRatingRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<RatingDto> PutRating(RatingDto rating)
    {
        var ratingEntity = _mapper.Map<RatingEntity>(rating);
        ratingEntity.RatingId = new Guid();
        var updatedRating = await _repository.UpdateAsync(ratingEntity);
        var mappedRating = _mapper.Map<RatingDto>(updatedRating);
        return mappedRating;
    }

    // public async Task<RatingDto> GetMovieUserRating(int movieId, Guid userId)
    // {
    //     return await _repository.GetMovieUserRating(movieId, userId);
    // }
}