namespace MovieManagement.Functions.Services;

public class RatingService : IRatingService
{
    private readonly IMapper _mapper;
    private readonly IRatingRepository _repository;
    private readonly IUserRepository _userRepository;

    public RatingService(IRatingRepository repository, IMapper mapper, IUserRepository userRepository)
    {
        _repository = repository;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<RatingDto> PutRating(RatingDto rating)
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

    public async Task<RatingDto> GetRatingById(Guid ratingId)
    {
        var ratingEntity =  await _repository.GetAsync(ratingId);
        return _mapper.Map<RatingDto>(ratingEntity);
    }

    public async Task<RatingDto> GetMovieRatingByUser(int movieId, Guid userId)
    {
        var ratingEntity = await _repository.GetMovieUserRating(movieId, userId);
        return _mapper.Map<RatingDto>(ratingEntity);
    }

    public async Task<IList<MovieRatingDto>> GetMovieRatings(GetRatingDto ratingDto, int pageNumber)
    {
        var movieRatingDtos = new List<MovieRatingDto>();
        var list = await _repository.GetMovieRatings(ratingDto.MovieId, ratingDto.UserId, pageNumber);
        var userIds = list.Select(r => r.UserId).ToList();
        var users = await _userRepository.GetUsers(userIds);

        movieRatingDtos.AddRange(from rating in list let user = users.FirstOrDefault(u => u.UserId == rating.UserId)
            select new MovieRatingDto 
                {   
                    Rating = (int)rating.Rating, 
                    Review = rating.Review, 
                    CreatedDate = rating.DateTime, 
                    CreatedBy = user?.Username 
                });
        
        return movieRatingDtos;
    }

    public async Task DeleteRating(Guid ratingId)
    {
        var existingRating = await GetRatingById(ratingId);
        if (existingRating is null)
        {
            throw new Exception("The rating with the given id does not exist");
        }
        await _repository.DeleteAsync(ratingId);
    }
}