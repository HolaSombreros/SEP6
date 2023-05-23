namespace MovieManagement.ViewModels.Index;

public class MovieViewModel
{
    public int Id { get; }
    public string Title { get;  }
    public string PosterPath { get; }
    public DateOnly ReleaseDate { get; }
    public double Rating { get; }

    public MovieViewModel(Movie movie)
    {
        Id = movie.Id;
        Title = movie.Title;
        PosterPath = movie.ImageUrl ?? "Images/MovieMissingPicture.png";
        ReleaseDate = DateOnly.FromDateTime(movie.ReleaseDate);
        Rating = movie.VoteAverage;
    }
    
    public MovieViewModel(MovieDto movie)
    {
        Id = movie.MovieId;
        Title = movie.Title;
        PosterPath = movie.PosterUrl ?? "Images/MovieMissingPicture.png";
        ReleaseDate = !string.IsNullOrEmpty(movie.ReleaseDate) ? DateOnly.Parse(movie.ReleaseDate) : default!;
    }
    
    public MovieViewModel(MovieDetailsViewModel movie)
    {
        Id = movie.Id;
        Title = movie.Title;
        PosterPath = movie.ImageUrl ?? "Images/MovieMissingPicture.png";
        ReleaseDate = DateOnly.FromDateTime(movie.ReleaseDate);
    }
}