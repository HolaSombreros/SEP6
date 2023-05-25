namespace MovieManagement.Functions.Validators;

public class GenreListValidator : AbstractValidator<IList<GenreDto>>
{
    public GenreListValidator()
    {
        RuleFor(x => x).NotEmpty().WithMessage("At least one genre must be provided");
        RuleForEach(x => x).SetValidator(new GenreDtoValidator());
    }
}