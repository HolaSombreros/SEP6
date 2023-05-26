namespace MovieManagement.FunctionDtos; 

public class AddMovieActorDto {
    public int MovieId { get; set; }
    public int MovieOrder { get; set; }
    public string? Title { get; set; }
    public string? PosterUrl { get; set; }
    public string? ReleaseDate { get; set; }

    [JsonConstructor]
    public AddMovieActorDto () { }
}