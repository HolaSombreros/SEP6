namespace MovieManagement.Models;

public class GenderDistributionModel
{
    public Dictionary<string, int> GenderDistribution { get; }

    public GenderDistributionModel(Dictionary<string, int> distribution)
    {
        GenderDistribution = distribution;
    }
}
