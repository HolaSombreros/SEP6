namespace MovieManagement.Functions.Dtos;

public class RatingDistributionByGenreDto
{
    public Dictionary<int, int>? RatingDistribution { get; set; }
    public double Average { get; set; }
    public int MaxRating { get; set; }
    public int MinRating { get; set; }
}