namespace MovieManagement.TMDB.Api.Dtos;

public class MovieCastDto
{
    public int Id { get; set; }
    public int Gender { get; set; }
    public string? Name { get; set; }
    public double Popularity { get; set; }
    public string? Character { get; set; }
    public int Order { get; set; }
    [JsonPropertyName("original_name")]
    public string? OriginalName { get; set; }
}