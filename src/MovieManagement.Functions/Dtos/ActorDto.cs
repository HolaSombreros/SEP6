namespace MovieManagement.Functions.Dtos; 

public class ActorDto {
    public int ActorId { get; set; }
    public List<AddMovieActorDto> Movies { get; set; }
    public int Gender { get; set; }
    public DateTime? Birthdate { get; set; }
    public string Name { get; set; }
}