namespace MovieManagement.ViewModels.PersonDetails;

public class PersonCastViewModel
{
    public int Id { get; }
    public string Name { get; }
    public string Character { get; }
    public string Title { get; }
    public string Description { get; }
    public string PosterUrl { get; }
    public string ReleaseDate { get; }
    public string VoteAverage { get; }
    public string VoteCount { get; }

    public PersonCastViewModel(Cast cast)
    {
        Id = cast.Id;
        Name = cast.Name;
        Character = cast.Character;
        Title = cast.Title;
        Description = cast.Description;
        PosterUrl = !string.IsNullOrEmpty(cast.PosterUrl) ? cast.PosterUrl : "Images/MovieMissingPicture.png";
        ReleaseDate = !cast.ReleaseDate.Equals(new DateTime(1, 1, 1))
            ? cast.ReleaseDate.ToString("dd/MM/yyyy")
            : string.Empty;
        VoteAverage = Math.Round(cast.VoteAverage, 2).ToString(CultureInfo.CurrentCulture);
        VoteCount = $"{cast.VoteCount:n0}";
    }
}