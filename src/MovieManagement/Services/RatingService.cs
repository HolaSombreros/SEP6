﻿namespace MovieManagement.Services;

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
        // TODO - change endpoint and put ids in body
        var endpoint = $"{settings.GetMovieRatings}/{movieId}/{userGuid}";
        //var dtos = await service.GetAsync<IEnumerable<ReviewResponseDto>>(endpoint, new object());
        var dtos = await DummyData.GetDummyReviews();

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
}
