namespace MovieManagement.ViewModels.Statistics;

public class AgeDistributionViewModel
{
    public AgeDistributionModel Data { get; private set; }
    public List<AgeDistributionDataModel> ChartData { get; private set; }

    public AgeDistributionViewModel(AgeDistributionModel model)
    {
        Data = model;
        ChartData = new List<AgeDistributionDataModel>();
        var orderedDictionary = model.AgeDistribution.OrderBy(pair => pair.Key);
        {
            foreach (var pair in orderedDictionary)
            {
                ChartData.Add(new AgeDistributionDataModel(pair.Key, pair.Value));
            }
        }
    }

    public class AgeDistributionDataModel
    {
        public string AgeRange { get; set; }
        public int Count { get; set; }

        public AgeDistributionDataModel(string ageRange, int count)
        {
            AgeRange = ageRange;
            Count = count;
        }
    }
}

