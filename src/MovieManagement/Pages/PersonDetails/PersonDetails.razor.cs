using MovieManagement.ViewModels.PersonDetails;

namespace MovieManagement.Pages.PersonDetails; 

public partial class PersonDetails {
    [Parameter] 
    public int Id { get; set; }
    private PersonViewModel _person = default!;
    
    protected override async Task OnInitializedAsync()
    {
        try
        {
            var credits = await PersonService.GetPersonCredits(Id);
            _person = new PersonViewModel(
                person: await PersonService.GetPersonDetails(Id),
                credits: credits);
        }
        catch (Exception)
        {
            _person = default!;
        }
    }
}