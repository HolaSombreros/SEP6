namespace MovieManagement.ViewModels.Search;

public class SearchPersonViewModel
{
    public int Id { get; }
    public string Name { get; }
    public string? KnownFor { get; }
    public string ImageUrl { get; }

    public SearchPersonViewModel(SearchPersonResult data)
    {
        Id = data.Id;
        Name = data.Name;
        KnownFor = data.KnownFor;
        ImageUrl = data.ProfilePath ?? "Images/CreditMemberMissingPicture.png";
    }
}
