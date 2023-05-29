namespace MovieManagement.Functions.Validators; 

public class ActorValidator : AbstractValidator<ActorDto> {
    public ActorValidator() {
        RuleFor(x => x.ActorId).NotEmpty();
        RuleFor(x => x.Gender).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
    }
}