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
}