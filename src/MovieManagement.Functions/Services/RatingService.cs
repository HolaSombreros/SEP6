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

    public async Task<MovieRatingDto> PutRatingAsync(MovieRatingDto rating)
    {
        var ratingEntity = _mapper.Map<RatingEntity>(rating);
        ratingEntity.UserEntity = (await _userRepository.GetAsync(rating.UserId))!;
        ratingEntity.MovieId = rating.MovieDto.MovieId;
        ratingEntity.DateTime = DateTime.UtcNow;
        var existingRating = await _repository.GetMovieUserRatingAsync(rating.MovieDto.MovieId, rating.UserId);
        if (existingRating != null)
        {
            var updatedRating = await _repository.UpdateAsync(ratingEntity, existingRating.RatingId);
            updatedRating!.RatingId = existingRating.RatingId;
            return _mapper.Map<MovieRatingDto>(updatedRating);
        }
        ratingEntity.RatingId = new Guid();
        var addedRating = await _repository.AddAsync(ratingEntity);
        return _mapper.Map<MovieRatingDto>(addedRating);
    }

    public async Task<MovieRatingDto> AddRatingAsync(MovieRatingDto ratingDto)
    {
        var ratingEntity = _mapper.Map<RatingEntity>(ratingDto);
        var addedRating = await _repository.AddAsync(ratingEntity);
        return _mapper.Map<MovieRatingDto>(addedRating);
    }

    public async Task<IList<RatingQueryDto>> GetMovieRatingsAsync(IList<int> ratingList)
    {
        var results = await _repository.GetAllMovieRatingsAsync(ratingList);
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

    public async Task<MovieRatingDto> GetRatingByIdAsync(Guid ratingId)
    {
        var ratingEntity =  await _repository.GetAsync(ratingId);
        return _mapper.Map<MovieRatingDto>(ratingEntity);
    }

    public async Task<MovieRatingDto> GetMovieRatingByUserAsync(int movieId, Guid userId)
    {
        var ratingEntity = await _repository.GetMovieUserRatingAsync(movieId, userId);
        return _mapper.Map<MovieRatingDto>(ratingEntity);
    }

    public async Task<RatingResultDto> GetMovieRatingsAsync(GetRatingDto ratingDto, int pageNumber)
    {
        var resultDto = new RatingResultDto();
        var list = await _repository.GetMovieRatingsAsync(ratingDto.MovieId, ratingDto.UserId, pageNumber);
        var userIds = list.ratingEntities.Select(r => r.UserId).ToList();
        var users = await _userRepository.GetUsersAsync(userIds);

        var movieRatingDtos = (from rating in list.ratingEntities let user = 
                users.FirstOrDefault(u => u!.UserId! == rating.UserId) 
            select new MovieRatingDto
            {
                RatingId = rating.RatingId,
                Rating = (int)rating.Rating, 
                Review = rating.Review, 
                CreatedDate = rating.DateTime, 
                CreatedBy = user?.Username
            }).ToList();

        resultDto.MovieRatingDtos = movieRatingDtos;
        resultDto.TotalResults = movieRatingDtos.Count;
        resultDto.Page = pageNumber;
        resultDto.TotalPages = list.totalPages;

        return resultDto;
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