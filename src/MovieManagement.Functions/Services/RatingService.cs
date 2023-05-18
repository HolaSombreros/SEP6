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

    public async Task<IList<RatingQueryDto>> GetMovieRatings(IList<int> ratingList)
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
}