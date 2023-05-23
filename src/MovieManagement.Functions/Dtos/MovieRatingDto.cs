namespace MovieManagement.Functions.Dtos;

public class MovieRatingDto
{
    public Guid Id { get; set; }
    public int Rating { get; set; }
    public string? Review { get; set; }
    public DateTime? CreatedDate { get; set; }
    public UserDto CreatedBy { get; set; } = null!;
}