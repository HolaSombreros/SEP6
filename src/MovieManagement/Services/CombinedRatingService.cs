namespace MovieManagement.Services;

public class CombinedRatingService : ICombinedRatingService
{
    private readonly IRatingService ratingService;
    private readonly IMovieService movieService;
    private readonly IPersonService personService;

    private const int ratingDecimalNumbers = 2;

    public CombinedRatingService(IRatingService ratingService, IMovieService movieService, IPersonService personService)
    {
        this.ratingService = ratingService;
        this.movieService = movieService;
        this.personService = personService;
    }

    public async Task<MovieList> GetMovieListAsync(ListType listType, int page)
    {
        var apiData = await movieService.GetMovieListAsync(listType, page);
        var dbData = await ratingService.GetMovieRatingsAsync(apiData.Movies.Select(movie => movie.Id).ToArray());

        foreach (var movie in dbData)
        {
            var apiMovie = apiData.Movies.First(m => m.Id == movie.MovieId);
            apiMovie.VoteAverage = Math.Round((apiMovie.VoteCount * apiMovie.VoteAverage + movie.VoteCount * movie.Average) / (apiMovie.VoteCount + movie.VoteCount), ratingDecimalNumbers);
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
            apiMovie.VoteAverage = Math.Round((apiMovie.VoteCount * apiMovie.VoteAverage + movie.VoteCount * movie.Average) / (apiMovie.VoteCount + movie.VoteCount), ratingDecimalNumbers);
            apiMovie.VoteCount += movie.VoteCount;
        }

        return apiMovie;
    }

    public async Task<Credits> GetPersonCreditsAsync(int personId)
    {
        var apiData = await personService.GetPersonCreditsAsync(personId);
        var dbData = await ratingService.GetMovieRatingsAsync(apiData.Cast.Select(m => m.Id).ToArray());

        foreach (var movie in dbData)
        {
            var apiCastMovie = apiData.Cast.FirstOrDefault(m => m.Id == movie.MovieId);
            if (apiCastMovie != null)
            {
                apiCastMovie.VoteAverage = Math.Round((apiCastMovie.VoteCount * apiCastMovie.VoteAverage + movie.VoteCount * movie.Average) / (apiCastMovie.VoteCount + movie.VoteCount), ratingDecimalNumbers);
                apiCastMovie.VoteCount += movie.VoteCount;
            }

            var apiCrewMovie = apiData.Crew.FirstOrDefault(m => m.Id == movie.MovieId);
            if (apiCrewMovie != null)
            {
                apiCrewMovie.VoteAverage = Math.Round((apiCrewMovie.VoteCount * apiCrewMovie.VoteAverage + movie.VoteCount * movie.Average) / (apiCrewMovie.VoteCount + movie.VoteCount), ratingDecimalNumbers);
                apiCrewMovie.VoteCount += movie.VoteCount;
            }
        }

        return apiData;
    }
}
