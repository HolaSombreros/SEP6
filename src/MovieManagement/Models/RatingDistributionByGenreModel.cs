namespace MovieManagement.Models;

public class RatingDistributionByGenreModel
{
    public Dictionary<int, int> RatingDistribution { get; }
    public double Average { get; }
    public int MaxRating { get; }
    public int MinRating { get; }

    public RatingDistributionByGenreModel(RatingDistributionByGenreDto dto)
    {
        RatingDistribution = dto.RatingDistribution;
        Average = Math.Round(dto.Average, 2);
        MinRating = dto.MinRating;
        MaxRating = dto.MaxRating;
    }
}
