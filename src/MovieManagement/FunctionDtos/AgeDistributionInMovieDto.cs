namespace MovieManagement.FunctionDtos; 

public class AgeDistributionInMovieDto
{
    public Dictionary<string, int> AgeDistribution { get; set; } = default!;
    public double AverageAge { get; set;  }
    public int Youngest { get; set;  }
    public int Oldest { get; set;  } 
    
    [JsonConstructor]
    public AgeDistributionInMovieDto()
    { }
}