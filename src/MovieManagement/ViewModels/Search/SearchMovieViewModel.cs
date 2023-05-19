namespace MovieManagement.ViewModels.Search;

public class SearchMovieViewModel
{
    public int Id { get; }
    public string Title { get; }
    public string PosterUrl { get; }
    public DateOnly? ReleaseDate { get; }

    public SearchMovieViewModel(SearchMovieResult data)
    {
        Id = data.Id;
        Title = data.Title;
        PosterUrl = data.PosterPath ?? "Images/MovieMissingPicture.png";
        if (data.ReleaseDate != null)
        {
            ReleaseDate = DateOnly.FromDateTime((DateTime)data.ReleaseDate);
        }
    }
}
