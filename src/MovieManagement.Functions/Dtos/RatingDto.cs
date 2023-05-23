namespace MovieManagement.Functions.Dtos;

public class RatingDto
{
    public MovieDto MovieDto { get; set; }
    public int Rating { get; set; }
    public string Review { get; set; }
    public Guid UserId { get; set; }
    public Guid RatingId { get; set; }
}