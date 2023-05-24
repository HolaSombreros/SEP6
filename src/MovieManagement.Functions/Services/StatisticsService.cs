namespace MovieManagement.Functions.Services;

public class StatisticsService : IStatisticsService
{
    private readonly IMovieGenreRepository _movieGenreRepository;
    private readonly IRatingRepository _ratingRepository;
    
    public StatisticsService(IRatingRepository ratingRepository, IMovieGenreRepository movieGenreRepository)
    {
        _ratingRepository = ratingRepository;
        _movieGenreRepository = movieGenreRepository;
    }

    public async Task<RatingDistributionByGenreDto> Get(int genreId)
    {
        var ratingDistribution = new RatingDistributionByGenreDto();
        var result = new Dictionary<int, int>();
        var movieGenres = await _movieGenreRepository.GetMoviesByGenre(genreId);
        var listIds = movieGenres.Select(mg => mg.MovieId).ToList();
        var ratings = await _ratingRepository.GetAllMovieRatingsAsync(listIds);

        var groupedRatings = ratings
            .GroupBy(r => (int)Math.Round(r.Rating, 1))
            .ToDictionary(g => g.Key, g => g.Count());
        
        for (var rating = 1; rating <= 10; rating++)
        {
            result[rating] = groupedRatings.GetValueOrDefault(rating, 0);
        }

        ratingDistribution.RatingDistribution = result;
        ratingDistribution.MaxRating = (int)ratings.Max(r => r.Rating);
        ratingDistribution.MinRating = (int)ratings.Min(r => r.Rating);
        ratingDistribution.Average = ratings.Average(r => (double)Math.Round(r.Rating, 2));
        return ratingDistribution;
    }
}