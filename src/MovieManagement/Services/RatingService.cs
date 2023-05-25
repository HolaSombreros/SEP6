namespace MovieManagement.Services;

public class RatingService : IRatingService
{
    private readonly IAzureService service;
    private readonly AzureFunctionsConfig settings;

    public event Action<ReviewModel>? OnReviewCreated;

    public RatingService(IAzureService service, IOptions<AzureFunctionsConfig> settings)
    {
        this.service = service;
        this.settings = settings.Value;
    }

    public async Task CreateMovieReviewAsync(CreateReviewModel reviewModel, MovieModel movieModel, Guid userGuid)
    {
        var dto = new CreateReviewDto(reviewModel, movieModel, userGuid);
        var review = await service.PutAsync<RatingDto>(settings.RateMoviePath, dto);
        OnReviewCreated?.Invoke(new ReviewModel(review));
    }

    public async Task<PaginatedReviewsModel> GetMovieReviewsAsync(int movieId, Guid? userGuid, int page)
    {
        var requestDto = new GetReviewsDto(movieId, userGuid);
        var responseDto = await service.GetAsync<ReviewsResponseDto>(settings.GetMovieRatings, requestDto, page);
        return new PaginatedReviewsModel(responseDto!);
    }

    public Task DeleteMovieReviewAsync(Guid reviewId)
    {
        return service.DeleteFromRouteAsync(settings.DeleteReviewPath, reviewId);
    }

    public async Task<ReviewModel?> GetUserMovieRating(int movieId, Guid userGuid)
    {
        var responseDto = await service.GetAsync<RatingDto?>($"{settings.GetMovieRating}/{movieId}/{userGuid}", new object());
        return responseDto != null
            ? new ReviewModel
            {
                Id = responseDto.RatingId,
            }
            : null;
    }

    public async Task<IList<MovieRatingModel>> GetMovieRatingsAsync(int[] movieIds)
    {
        var responseDto = await service.GetAsync<IList<MovieRatingDto>>(settings.GetMovieRatingsByIdsPath, movieIds);
        var output = new List<MovieRatingModel>();

        foreach (var dto in responseDto!)
        {
            output.Add(new MovieRatingModel(dto));
        }

        return output;
    }
}
