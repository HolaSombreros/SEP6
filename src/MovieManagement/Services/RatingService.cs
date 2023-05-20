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

    public async Task<List<ReviewModel>> GetMovieReviewsAsync(int movieId, Guid? userGuid)
    {
        // TODO - change endpoint and put ids in body
        var endpoint = $"{settings.GetMovieRatings}/{movieId}/{userGuid}";
        var dtos = await service.GetAsync<IEnumerable<ReviewResponseDto>>(endpoint, new object());

        if (dtos.Any())
        {
            var output = new List<ReviewModel>();

            foreach (var dto in dtos)
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

    public async Task<RatingViewModel> RateMovieAsync(RatingViewModel ratingViewModel, MovieDetailsViewModel movieDetailsViewModel, Guid userId)
    {
        var ratingDto = new AddRatingDto(ratingViewModel, movieDetailsViewModel, userId);
        var newRating = await service.PutAsync<RatingDto>(settings.RateMoviePath, ratingDto);
        ratingViewModel.RatingId = newRating.RatingId;
        return ratingViewModel;
    }
}
