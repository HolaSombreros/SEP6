namespace MovieManagement.ViewModels.Statistics;

public class GenderByGenreViewModel
{
    public GenderDistributionModel Data { get; private set; }
    public List<GenderByGenreDataModel> ChartData { get; private set; }

    public GenderByGenreViewModel(GenderDistributionModel data)
    {
        Data = data;
        ChartData = new List<GenderByGenreDataModel>();
        foreach (var pair in data.GenderDistribution.OrderByDescending(pair => pair.Value))
        {
            ChartData.Add(new GenderByGenreDataModel(pair.Key, pair.Value));
        }
    }

    public class GenderByGenreDataModel
    {
        public string Gender { get; set; }
        public int Count { get; set; }

        public GenderByGenreDataModel(string gender, int count)
        {
            Gender = gender;
            Count = count;
        }
    }
}
