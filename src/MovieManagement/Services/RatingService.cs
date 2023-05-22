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

    public async Task<IEnumerable<ReviewModel>> GetMovieReviewsAsync(int movieId, Guid? userGuid)
    {
        var requestDto = new GetReviewsDto(movieId, userGuid);
        var responseDtos = await service.GetAsync<IEnumerable<ReviewResponseDto>>(settings.GetMovieRatings, requestDto);
        //var dtos = await DummyData.GetDummyReviews();

        if (responseDtos.Any())
        {
            var output = new List<ReviewModel>();

            foreach (var dto in responseDtos)
            {
                output.Add(new ReviewModel(dto));
            }

            return output;
        }
        else
        {
            return new List<ReviewModel>();
        }
    }
}
