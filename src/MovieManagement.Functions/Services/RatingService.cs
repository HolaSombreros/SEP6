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

    public async Task<RatingDto> PutRatingAsync(RatingDto rating)
    {
        var ratingEntity = _mapper.Map<RatingEntity>(rating);
        ratingEntity.MovieId = rating.MovieDto.MovieId;
        ratingEntity.DateTime = DateTime.UtcNow;
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

    public async Task<RatingDto> AddRatingAsync(RatingDto ratingDto)
    {
        var ratingEntity = _mapper.Map<RatingEntity>(ratingDto);
        var addedRating = await _repository.AddAsync(ratingEntity);
        return _mapper.Map<RatingDto>(addedRating);
    }

    public async Task<IList<RatingQueryDto>> GetMovieRatingsAsync(IList<int> ratingList)
    {
        var results = await _repository.GetAllMovieRatings(ratingList);
        var mappedRating = _mapper.Map<List<RatingSubsetDto>>(results);
        return mappedRating
            .GroupBy(r => r.MovieId)
            .Select(g => new RatingQueryDto
            {
                MovieId = g.Key,
                Average = Math.Round(g.Average(r => r.Rating),2),
                VoteCount = g.Count()
            })
            .ToList();
    }

    public async Task<RatingDto> GetRatingByIdAsync(Guid ratingId)
    {
        var ratingEntity =  await _repository.GetAsync(ratingId);
        return _mapper.Map<RatingDto>(ratingEntity);
    }

    public async Task<RatingDto> GetMovieRatingByUserAsync(int movieId, Guid userId)
    {
        var ratingEntity = await _repository.GetMovieUserRating(movieId, userId);
        return _mapper.Map<RatingDto>(ratingEntity);
    }

    public async Task<IList<RatingDto>> GetMovieRatingsAsync(int movieId, Guid userId, int pageNumber, int pageSize)
    {
        var list = await _repository.GetMovieRatings(movieId, userId, pageNumber, pageSize);
        return _mapper.Map<List<RatingDto>>(list);
    }

    public async Task DeleteRatingAsync(Guid ratingId)
    {
        var existingRating = await GetRatingByIdAsync(ratingId);
        if (existingRating is null)
        {
            throw new Exception("The rating with the given id does not exist");
        }
        await _repository.DeleteAsync(ratingId);
    }
}