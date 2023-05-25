namespace MovieManagement.Functions.Validators;

public class GetRatingDtoValidator : AbstractValidator<GetRatingDto> 
{
    public GetRatingDtoValidator()
    {
        RuleFor(x => x.MovieId).NotNull().WithMessage("Movie id must be provided");
    }
}