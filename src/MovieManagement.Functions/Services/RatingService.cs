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
        ratingEntity.MovieId = rating.MovieDto.MovieId;
        var existingRating = await _repository.GetMovieUserRating(rating.MovieDto.MovieId, rating.UserId);
        if (existingRating != null)
        {
            var updatedRating = await _repository.UpdateAsync(ratingEntity, existingRating.RatingId);
            return _mapper.Map<RatingDto>(updatedRating);
        }
        ratingEntity.RatingId = new Guid();
        var addedRating = await _repository.AddAsync(ratingEntity);
        return _mapper.Map<RatingDto>(addedRating);
    }

    public async Task<RatingDto> AddRating(RatingDto ratingDto)
    {
        var ratingEntity = _mapper.Map<RatingEntity>(ratingDto);
        var addedRating = await _repository.AddAsync(ratingEntity);
        return _mapper.Map<RatingDto>(addedRating);
    }
}