namespace MovieManagement.ViewModels;

public class ProductionCompanyViewModel
{
    public string Name { get; }
    public string Country { get; }

    public ProductionCompanyViewModel(ProductionCompany productionCompany)
    {
        Name = productionCompany.Name;
        Country = productionCompany.Country;
    }
}