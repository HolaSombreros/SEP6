namespace MovieManagement.Functions.Dtos; 

public class AgeDistributionInMovieDto {
    public Dictionary<string, int>? AgeDistribution { get; set; }
    public double AverageAge { get; set; }
    public int Youngest { get; set; }
    public int Oldest { get; set; }
}