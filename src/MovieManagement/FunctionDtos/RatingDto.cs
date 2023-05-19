namespace MovieManagement.FunctionDtos;

public class RatingDto
{
    public MovieDto MovieDto { get; set; } = default!;
    public int Rating { get; set; }
    public string Review { get; set; } = default!;
    public Guid UserId { get; set; }
    public Guid RatingId { get; set; }
}
