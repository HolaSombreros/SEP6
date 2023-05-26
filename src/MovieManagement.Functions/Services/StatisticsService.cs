namespace MovieManagement.Functions.Services;

public class StatisticsService : IStatisticsService
{
    private readonly IMovieGenreRepository _movieGenreRepository;
    private readonly IRatingRepository _ratingRepository;
    private readonly IActorRepository _actorRepository;
    
    public StatisticsService(IRatingRepository ratingRepository, IMovieGenreRepository movieGenreRepository, IActorRepository actorRepository)
    {
        _ratingRepository = ratingRepository;
        _movieGenreRepository = movieGenreRepository;
        _actorRepository = actorRepository;
    }

    public async Task<RatingDistributionByGenreDto> GetGenreDistributionAsync(int genreId)
    {
        if (genreId < 1)
        {
            throw new Exception("The genre id must be provided");
        }
        var ratingDistribution = new RatingDistributionByGenreDto();
        var result = new Dictionary<int, int>();
        var movieGenres = await _movieGenreRepository.GetMoviesByGenre(genreId);
        var listIds = movieGenres.Select(mg => mg!.MovieId).ToList();
        var ratings = await _ratingRepository.GetAllMovieRatingsAsync(listIds);

        var groupedRatings = ratings
            .GroupBy(r => (int)Math.Round(r.Rating, 1))
            .ToDictionary(g => g.Key, g => g.Count());
        
        for (var rating = 1; rating <= 10; rating++)
        {
            result[rating] = groupedRatings.GetValueOrDefault(rating, 0);
        }

        ratingDistribution.RatingDistribution = result;
        ratingDistribution.MaxRating = ratings.Count > 0 ? (int)ratings.Max(r => r.Rating) : 0;
        ratingDistribution.MinRating = ratings.Count > 0 ? (int)ratings.Min(r => r.Rating) : 0;
        ratingDistribution.Average = ratings.Count > 0 ? (double)Math.Round(ratings.Average(r => r.Rating), 2) : 0;
        return ratingDistribution;
    }

    public async Task<AgeDistributionInMovieDto> GetAgeDistributionAsync(int movieId) {
        if (movieId < 1) {
            throw new Exception("The movie id must be provided");
        }

        var birthdates = await _actorRepository.GetAgesByMovieAsync(movieId);
        if (!birthdates.Any()) {
            throw new Exception("Currently missing data on actors for this movie");
        }
        var ages = new List<int>();
        var intervalSize = 10;
        foreach (var  bd in birthdates) {
            ages.Add(CalculateAge(bd));
        }

        var distribution = ages.GroupBy(a => GetIntervalKey(a, intervalSize)).ToDictionary(r => r.Key.ToString(), r => r.Count());

        var ageDistribution = new AgeDistributionInMovieDto {
            AgeDistribution = distribution,
            AverageAge = ages.Average(),
            Oldest = ages.Max(),
            Youngest = ages.Min()
        };
        return ageDistribution;
    }

    public async Task<Dictionary<string,int>> GetGenderDistributionInMainRoles(int genreId) {
        Dictionary<int,string> genders = new Dictionary<int,string>()
        {
            { 0, "Unknown"},
            { 1, "Female" },
            { 2, "Male" },
            { 3, "Nonbinary" }
        };

        var result = new Dictionary<string, int>() {
            { "Unknown", 0 },
            { "Female", 0 },
            { "Male", 0 },
            { "Nonbinary", 0 }
        };
        
        var genderList = await _actorRepository.GetGenderForActorsInMainRoleByGenre(genreId);
        
        if (genderList.Count == 0) {
            throw new Exception("Currently missing data on main actors for this genre");

        }
        foreach (var gender in genderList) {
            result[genders[gender]]++;
        }

        return result;
    }

    private int CalculateAge(string birthday)
    {
        if (string.IsNullOrWhiteSpace(birthday)) {
            return 0;
        }

        DateTime empBirthday = Convert.ToDateTime(birthday);
        DateTime today = DateTime.Today;
        int age = today.Year - empBirthday.Year;
        if (empBirthday > today.AddYears(-age)) {
            age--;
        }
        return age;
    }
    
    static string GetIntervalKey(int age, int intervalSize)
    {
        int lowerBound = (age / intervalSize) * intervalSize;
        int upperBound = lowerBound + intervalSize - 1;
        return $"{lowerBound}-{upperBound}";
    }
}