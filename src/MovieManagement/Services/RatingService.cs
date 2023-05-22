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

    public Task CreateMovieReview(CreateReviewModel reviewModel, MovieModel movieModel, Guid userGuid)
    {
        var dto = new CreateReviewDto(reviewModel, movieModel, userGuid);
        return service.PutAsync<RatingDto>(settings.RateMoviePath, dto);
    }

    public async Task<PaginatedReviewsModel> GetMovieReviewsAsync(int movieId, Guid? userGuid, int page)
    {
        var requestDto = new GetReviewsDto(movieId, userGuid);
        var responseDto = await service.GetAsync<ReviewsResponseDto>(settings.GetMovieRatings, requestDto, page);
        return new PaginatedReviewsModel(responseDto);
    }
}
