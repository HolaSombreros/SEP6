namespace MovieManagement.Models;

public class MovieRatingModel
{
    public int MovieId { get; set; }
    public double Average { get; set; }
    public int VoteCount { get; set; }

    public MovieRatingModel(MovieRatingDto dto)
    {
        MovieId = dto.MovieId;
        Average = dto.Average;
        VoteCount = dto.VoteCount;
    }
}
