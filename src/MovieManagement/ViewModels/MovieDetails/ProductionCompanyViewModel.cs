namespace MovieManagement.ViewModels.MovieDetails;

public class ProductionCompanyViewModel
{
    public string Name { get; }
    public string Country { get; }
    public string LogoPath { get; }

    public ProductionCompanyViewModel(ProductionCompany productionCompany)
    {
        Name = productionCompany.Name;
        Country = productionCompany.Country;
        LogoPath = productionCompany.LogoPath;
    }
}