namespace MovieManagement.Functions.Validators;

public class GenreListValidator : AbstractValidator<IList<GenreDto>>
{
    public GenreListValidator()
    {
        RuleForEach(x => x).SetValidator(new GenreDtoValidator());
    }
}