namespace MovieManagement.ViewModels.PersonDetails;

public class PersonCastViewModel {
    public int Id { get; }
    public int Gender { get; }
    public string Name { get; }
    public string Character { get; }
    public string OriginalName { get; }
    public string ImageUrl { get; }
    public string Title { get; }
    public string Description { get; }
    public string PosterUrl { get; }
    public string ReleaseDate { get; }
    public double VoteAverage { get; }
    public int VoteCount { get; }

    public PersonCastViewModel(Cast cast) {
        Id = cast.Id;
        Gender = cast.Gender;
        Name = cast.Name;
        Character = cast.Character;
        OriginalName = cast.OriginalName;
        ImageUrl = !string.IsNullOrEmpty(cast.ImageUrl) ? cast.ImageUrl : "Images/CreditMemberMissingPicture.png";
        Title = cast.Title;
        Description = cast.Description;
        PosterUrl = cast.PosterUrl;
        ReleaseDate = cast.ReleaseDate.ToString("dd/MM/yyyy");
        VoteAverage = cast.VoteAverage;
        VoteCount = cast.VoteCount;
    }
}