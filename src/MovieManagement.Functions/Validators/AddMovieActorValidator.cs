namespace MovieManagement.Functions.Validators; 

public class AddMovieActorValidator : AbstractValidator<AddMovieActorDto> {
    public AddMovieActorValidator() {
        RuleFor(x => x.MovieId).NotEmpty();
    }
}