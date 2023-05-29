namespace MovieManagement.Models;

public class AgeDistributionModel
{
    public Dictionary<string, int> AgeDistribution { get; }
    public double AverageAge { get; }
    public int Oldest { get; }
    public int Youngest { get; }

    public AgeDistributionModel(AgeDistributionInMovieDto dto)
    {
        AgeDistribution = dto.AgeDistribution;
        AverageAge = Math.Round(dto.AverageAge, 1);
        Youngest = dto.Youngest;
        Oldest = dto.Oldest;
    }
}
