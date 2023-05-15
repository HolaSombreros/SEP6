namespace MovieManagement.ViewModels.Index;

public class MovieViewModel
{
    public int Id { get; }
    public string Title { get;  }
    public string PosterPath { get; set; }
    public DateOnly ReleaseDate { get; }
    public List<RatingViewModel> Ratings { get; }

    public MovieViewModel(Movie movie)
    {
        Id = movie.Id;
        Title = movie.Title;
        PosterPath = movie.ImageUrl;
        ReleaseDate = DateOnly.FromDateTime(movie.ReleaseDate);
        Ratings = new List<RatingViewModel>();
        // TODO - Map ratings.
    }
}