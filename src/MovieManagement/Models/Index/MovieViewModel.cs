namespace MovieManagement.Models.Index;

public class MovieViewModel
{
  public int Id { get; set; } = default!;
  public string Title { get; set; } = default!;
  public string PosterPath { get; set; } = default!;
  public DateOnly ReleaseDate { get; set; } = default!;
  public List<RatingViewModel> Ratings { get; set; } = new();

  public MovieViewModel(Movie movie)
  {
    Id = movie.Id;
    Title = movie.Title;
    PosterPath = movie.ImageUrl;
    ReleaseDate = DateOnly.FromDateTime(movie.ReleaseDate);
    // TODO - Map ratings.
  }

  public MovieViewModel()
  {

  }
}
