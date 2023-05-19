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

    public async Task<RatingViewModel> RateMovie(RatingViewModel ratingViewModel, MovieDetailsViewModel movieViewModel, Guid userId)
    {
        var ratingDto = new AddRatingDto(ratingViewModel, movieViewModel, userId);
        var newRating = await service.PutAsync<RatingDto>(settings.RateMoviePath, ratingDto);
        ratingViewModel.RatingId = newRating.RatingId;
        return ratingViewModel;
    }
}
