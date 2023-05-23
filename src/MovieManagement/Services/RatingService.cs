namespace MovieManagement.Services;

public class RatingService : IRatingService
{
    private readonly IAzureService service;
    private readonly AzureFunctionsConfig settings;

    public RatingService(IAzureService service, IOptions<AzureFunctionsConfig> settings)
    {
        this.service = service;
        this.settings = settings.Value;
    }

    public Task CreateMovieReviewAsync(CreateReviewModel reviewModel, MovieModel movieModel, Guid userGuid)
    {
        var dto = new CreateReviewDto(reviewModel, movieModel, userGuid);
        return service.PutAsync<RatingDto>(settings.RateMoviePath, dto);
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
}
