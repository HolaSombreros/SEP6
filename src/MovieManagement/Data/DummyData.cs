namespace MovieManagement.Data;

public class DummyData
{
    public static List<MovieListViewModel> GetCustomMovieLists()
    {
        var data = new List<MovieListViewModel>()
        {
            new MovieListViewModel
            {
                Id = "1",
                Name = "ToWatch",
            },
            new MovieListViewModel
            {
                Id = "2",
                Name = "Favourites",
            },
            new MovieListViewModel
            {
                Id = "3",
                Name = "My first list",
            },
            new MovieListViewModel
            {
                Id = "4",
                Name = "My second list",
            }
        };

        return data;
    }
}