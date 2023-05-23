namespace MovieManagement.Services;

public class CombinedRatingService : ICombinedRatingService
{
    private readonly IRatingService ratingService;
    private readonly IMovieService movieService;

    public CombinedRatingService(IRatingService ratingService, IMovieService movieService)
    {
        this.ratingService = ratingService;
        this.movieService = movieService;
    }

    public async Task<MovieList> GetMovieListAsync(ListType listType, int page)
    {
        var apiData = await movieService.GetMovieListAsync(listType, page);
        var dbData = await ratingService.GetMovieRatingsAsync(apiData.Movies.Select(movie => movie.Id).ToArray());

        foreach (var movie in dbData)
        {
            var apiMovie = apiData.Movies.First(m => m.Id == movie.MovieId);
            apiMovie.VoteAverage = Math.Round((apiMovie.VoteCount * apiMovie.VoteAverage + movie.VoteCount * movie.Average) / (apiMovie.VoteCount + movie.VoteCount), 1);
            apiMovie.VoteCount += movie.VoteCount;
        }

        return apiData;
    }

    public async Task<Movie> GetMovieByIdAsync(int id)
    {
        var apiMovie = await movieService.GetMovieByIdAsync(id);
        var dbMovies = await ratingService.GetMovieRatingsAsync(new int[] { id });

        if (dbMovies.Any())
        {
            var movie = dbMovies.First(m => m.MovieId == id);
            apiMovie.VoteAverage = Math.Round((apiMovie.VoteCount * apiMovie.VoteAverage + movie.VoteCount * movie.Average) / (apiMovie.VoteCount + movie.VoteCount), 1);
            apiMovie.VoteCount += movie.VoteCount;
        }

        return apiMovie;
    }

    // ActorDetails
}
