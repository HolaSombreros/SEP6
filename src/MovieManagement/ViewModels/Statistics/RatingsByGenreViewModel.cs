namespace MovieManagement.ViewModels.Statistics;

public class RatingsByGenreViewModel
{
    private readonly IStatsService statsService;
    private readonly IGenreService genreService;

    public List<Genre>? Genres { get; private set; }
    public RatingDistributionByGenreModel Data { get; private set; } = null!;
    public List<RatingByGenreDataModel>? ChartData { get; private set; }

    public RatingsByGenreViewModel(IStatsService statsService, IGenreService genreService)
    {
        this.statsService = statsService;
        this.genreService = genreService;
    }

    public async Task InitAsync()
    {
        var genres = await genreService.GetAllGenresAsync()!;
        Genres = new();

        foreach (var genre in genres.Genres!)
        {
            Genres.Add(genre!);
        }
    }

    public async Task GetRatingDistributionsAsync(ChangeEventArgs args)
    {
        int genreId = int.Parse(args.Value!.ToString()!);
        Data = await statsService.GetRatingDistributionByGenreAsync(genreId);
        ChartData = new();

        foreach (var key in Data.RatingDistribution.Keys)
        {
            ChartData.Add(new RatingByGenreDataModel
            {
                Rating = key.ToString(),
                Count = Data.RatingDistribution[key]
            });
        }
    }

    public class RatingByGenreDataModel
    {
        public string Rating { get; set; } = null!;
        public int Count { get; set; }
    }
}
