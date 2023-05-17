namespace MovieManagement.ViewModels.MovieDetails;

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
        ImageUrl = !string.IsNullOrEmpty(cast.ImageUrl) ? cast.ImageUrl : "Images/CreditMemberMissingPicture.png";
    }
}