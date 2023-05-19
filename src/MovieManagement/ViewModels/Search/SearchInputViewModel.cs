namespace MovieManagement.ViewModels.Search;

public class SearchInputViewModel
{
    [MinLength(3, ErrorMessage = "Minimum {1} chacters")]
    public string SearchInput { get; set; } = "";
}
