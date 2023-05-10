namespace MovieManagement.ViewModels;

public class MovieDetailsCastViewModel
{
    public int Id { get; }
    public string Name { get; }
    public string Character { get; }
    public string ImageUrl { get; }

    public MovieDetailsCastViewModel(Cast cast)
    {
        Id = cast.Id;
        Name = cast.Name;
        Character = cast.Character;
        ImageUrl = cast.ImageUrl;
    }
}