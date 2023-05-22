namespace MovieManagement.Functions.Dtos;

public class GetRatingDto
{
    public int? MovieId { get; set; }
    public Guid? UserId { get; set; }
}