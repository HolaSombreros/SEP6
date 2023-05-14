namespace MovieManagement.TMDB.Api.Dtos;

public class PersonDto
{
    public int Id { get; set; }
    public DateTime Birthday { get; set; }
    public string Name { get; set; } = default!;
    public string Biography { get; set; } = default!;
    public string DeathDay { get; set; } = default!; 
    [JsonPropertyName("place_of_birth")]
    public string PlaceOfBirth { get; set; } = default!;
    [JsonPropertyName("profile_path")]
    public string ImageUrl { get; set; } = default!;
    public double Popularity { get; set; }
}