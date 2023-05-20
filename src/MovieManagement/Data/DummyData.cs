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

    public static async Task<List<ReviewResponseDto>> GetDummyReviews()
    {
        return new List<ReviewResponseDto>
        {
            new ReviewResponseDto {
                Rating = 5,
                Review = "Could be better...",
                Created = DateTime.Now,
                CreatedBy = new UserDto
                {
                    Username = "SomeRandomDude"
                }
            },
            new ReviewResponseDto {
                Rating = 9,
                Review = "Absolutely fantastic!",
                Created = DateTime.Now,
                CreatedBy = new UserDto
                {
                    Username = "AnotherGuy"
                }
            },
            new ReviewResponseDto {
                Rating = 3,
                Review = "Meh.",
                Created = DateTime.Now,
                CreatedBy = new UserDto
                {
                    Username = "IHateMovies"
                }
            },
            new ReviewResponseDto {
                Rating = 10,
                Review = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Quis ipsum suspendisse ultrices gravida dictum. Eu augue ut lectus arcu. Commodo quis imperdiet massa tincidunt nunc pulvinar sapien et. Id porta nibh venenatis cras sed felis eget. Donec adipiscing tristique risus nec feugiat. Purus non enim praesent elementum facilisis leo vel fringilla est. Nisl nunc mi ipsum faucibus vitae aliquet nec. Est pellentesque elit ullamcorper dignissim cras. Ut faucibus pulvinar elementum integer. Sagittis eu volutpat odio facilisis mauris sit amet massa. In massa tempor nec feugiat nisl pretium. Tellus mauris a diam maecenas sed enim ut sem viverra.",
                Created = DateTime.Now,
                CreatedBy = new UserDto
                {
                    Username = "ILoveMovies"
                }
            }
        };
    }
}