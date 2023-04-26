namespace MovieManagement.TMDB.Api.Dtos;

public class MovieDto
{
    public int Id { get; set; }
    public int Budget { get; set; }
    public int Revenue { get; set; }
    public string Title { get; set; }
    [JsonPropertyName("release_date")]
    public string ReleaseDate { get; set; }
    
}