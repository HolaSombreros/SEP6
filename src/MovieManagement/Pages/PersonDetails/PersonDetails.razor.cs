using MovieManagement.ViewModels.PersonDetails;

namespace MovieManagement.Pages.PersonDetails;

public partial class PersonDetails : ComponentBase
{
    [Parameter] 
    public int Id { get; set; }
    private PersonViewModel _person = default!;
    private string _message = "Loading...";

    protected override async Task OnInitializedAsync()
    {
        try
        {
            var credits = await PersonService.GetPersonCredits(Id);
            var person = await PersonService.GetPersonDetails(Id);
            if (person.Id != 0)
            {
                _person = new PersonViewModel(
                    person: await PersonService.GetPersonDetails(Id),
                    credits: credits);
            }
            else
            {
                _message = "No person found with this id";
            }
        }
        catch (Exception)
        {
            _person = default!;
        }
    }
}