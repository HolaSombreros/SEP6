
namespace MovieManagement.Functions.Dtos; 

public class MovieActorDto {
    public int ActorId { get; set; }
    public int MovieId { get; set; }
    [JsonPropertyName("order")]
    public int MovieOrder { get; set; }
}