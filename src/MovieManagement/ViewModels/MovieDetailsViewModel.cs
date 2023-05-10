namespace MovieManagement.ViewModels;

public class MovieDetailsViewModel
{
    public int Id { get; }
    public string Title { get; }
    public int Revenue { get; }
    public DateTime ReleaseDate { get; }
    public int Budget { get; }
    public string Description { get; }
    public bool IsAdult { get; }
    public string ImageUrl { get; }

    public MovieDetailsViewModel(Movie movie)
    {
        Id = movie.Id;
        Title = movie.Title;
        Revenue = movie.Revenue;
        ReleaseDate = movie.ReleaseDate;
        Budget = movie.Budget;
        Description = movie.Description;
        IsAdult = movie.IsAdult;
        ImageUrl = movie.ImageUrl;
    }
}