namespace MovieManagement.ViewModels.Index;

public class MovieViewModel
{
    public int Id { get; }
    public string Title { get; }
    public string PosterPath { get; }
    public DateOnly ReleaseDate { get; }
    public double Rating { get; }
    public IList<Genre> Genres { get; set; } = new List<Genre>();

    public MovieViewModel(Movie movie)
    {
        Id = movie.Id;
        Title = movie.Title;
        PosterPath = movie.ImageUrl ?? "Images/MovieMissingPicture.png";
        ReleaseDate = DateOnly.FromDateTime(movie.ReleaseDate ?? new DateTime(1,1,1));
        Rating = movie.VoteAverage;
        Genres = movie.Genres;
    }

    public MovieViewModel(MovieDto movie)
    {
        Id = movie.MovieId;
        Title = movie.Title;
        PosterPath = movie.PosterUrl ?? "Images/MovieMissingPicture.png";
        ReleaseDate = !string.IsNullOrEmpty(movie.ReleaseDate) ?
            DateOnly.FromDateTime(DateTime.ParseExact(movie.ReleaseDate, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture)) :
            default!;
    }

    public MovieViewModel(MovieDetailsViewModel movie)
    {
        Id = movie.Id;
        Title = movie.Title;
        PosterPath = movie.ImageUrl ?? "Images/MovieMissingPicture.png";
        ReleaseDate = DateOnly.FromDateTime(movie.ReleaseDate);
        Genres = movie.Genres;
    }
}