namespace MovieManagement.ViewModels.PersonDetails;

public class PersonCastViewModel
{
    public int Id { get; }
    public string Name { get; }
    public string Character { get; }
    public string Title { get; }
    public string Description { get; }
    public string PosterUrl { get; }
    public DateTime ReleaseDate { get; }
    public double VoteAverage { get; }
    public int VoteCount { get; }

    public PersonCastViewModel(Cast cast)
    {
        Id = cast.Id;
        Name = cast.Name;
        Character = cast.Character;
        Title = cast.Title;
        Description = cast.Description;
        PosterUrl = !string.IsNullOrEmpty(cast.PosterUrl) ? cast.PosterUrl : "Images/MovieMissingPicture.png";
        ReleaseDate = cast.ReleaseDate;
        VoteAverage = Math.Round(cast.VoteAverage, 2);
        VoteCount = cast.VoteCount;
    }
}