namespace MovieManagement.Functions.Dtos; 

public class GenderDistributionInMainRolesDto {
    public Dictionary<string, int> GenderDistribution { get; set; } = default!;
}