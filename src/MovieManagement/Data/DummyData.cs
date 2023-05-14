using MovieManagement.Models.Index;

namespace MovieManagement.Data;

public class DummyData
{
  public static async Task<MoviesViewModel> GetMovies()
  {
    return await Task.FromResult(
      new MoviesViewModel()
      {
        Movies = new()
        {
          new()
          {
            Id = 640146,
            PosterPath = "/ngl2FKBlU4fhbdsrtdom9LVLBXw.jpg",
            Title = "The Lord of the Rings",
            ReleaseDate = DateOnly.FromDateTime(DateTime.Now),
            Ratings = new List<RatingViewModel>
            {
              new RatingViewModel
              {
                Review = "Hello, Vlad",
                StarRating = 3
              },
              new RatingViewModel
              {
                Review = "Hello, Vlad",
                StarRating = 1
              },
              new RatingViewModel
              {
                Review = "Hello, Vlad",
                StarRating = 8
              }
            }
          },
          new()
          {
            Id = 502356,
            PosterPath = "/qNBAXBIQlnOThrVvA6mA2B5ggV6.jpg",
            Title = "Harry Potter",
            ReleaseDate = DateOnly.FromDateTime(DateTime.Now),
            Ratings = new List<RatingViewModel>
            {
              new RatingViewModel
              {
                Review = "Hello, Vlad",
                StarRating = 3
              },
              new RatingViewModel
              {
                Review = "Hello, Vlad",
                StarRating = 1
              },
              new RatingViewModel
              {
                Review = "Hello, Vlad",
                StarRating = 8
              }
            }
          },
          new()
          {
            Id = 640146,
            PosterPath = "/ngl2FKBlU4fhbdsrtdom9LVLBXw.jpg",
            Title = "The Lord of the Rings",
            ReleaseDate = DateOnly.FromDateTime(DateTime.Now),
            Ratings = new List<RatingViewModel>
            {
              new RatingViewModel
              {
                Review = "Hello, Vlad",
                StarRating = 3
              },
              new RatingViewModel
              {
                Review = "Hello, Vlad",
                StarRating = 1
              },
              new RatingViewModel
              {
                Review = "Hello, Vlad",
                StarRating = 8
              }
            }
          },
          new()
          {
            Id = 502356,
            PosterPath = "/qNBAXBIQlnOThrVvA6mA2B5ggV6.jpg",
            Title = "Harry Potter",
            ReleaseDate = DateOnly.FromDateTime(DateTime.Now),
            Ratings = new List<RatingViewModel>
            {
              new RatingViewModel
              {
                Review = "Hello, Vlad",
                StarRating = 3
              },
              new RatingViewModel
              {
                Review = "Hello, Vlad",
                StarRating = 1
              },
              new RatingViewModel
              {
                Review = "Hello, Vlad",
                StarRating = 8
              }
            }
          },
          new()
          {
            Id = 640146,
            PosterPath = "/ngl2FKBlU4fhbdsrtdom9LVLBXw.jpg",
            Title = "The Lord of the Rings",
            ReleaseDate = DateOnly.FromDateTime(DateTime.Now),
            Ratings = new List<RatingViewModel>
            {
              new RatingViewModel
              {
                Review = "Hello, Vlad",
                StarRating = 3
              },
              new RatingViewModel
              {
                Review = "Hello, Vlad",
                StarRating = 1
              },
              new RatingViewModel
              {
                Review = "Hello, Vlad",
                StarRating = 8
              }
            }
          },
          new()
          {
            Id = 502356,
            PosterPath = "/qNBAXBIQlnOThrVvA6mA2B5ggV6.jpg",
            Title = "Harry Potter",
            ReleaseDate = DateOnly.FromDateTime(DateTime.Now),
            Ratings = new List<RatingViewModel>
            {
              new RatingViewModel
              {
                Review = "Hello, Vlad",
                StarRating = 3
              },
              new RatingViewModel
              {
                Review = "Hello, Vlad",
                StarRating = 1
              },
              new RatingViewModel
              {
                Review = "Hello, Vlad",
                StarRating = 8
              }
            }
          },
          new()
          {
            Id = 640146,
            PosterPath = "/ngl2FKBlU4fhbdsrtdom9LVLBXw.jpg",
            Title = "The Lord of the Rings",
            ReleaseDate = DateOnly.FromDateTime(DateTime.Now),
            Ratings = new List<RatingViewModel>
            {
              new RatingViewModel
              {
                Review = "Hello, Vlad",
                StarRating = 3
              },
              new RatingViewModel
              {
                Review = "Hello, Vlad",
                StarRating = 1
              },
              new RatingViewModel
              {
                Review = "Hello, Vlad",
                StarRating = 8
              }
            }
          },
          new()
          {
            Id = 502356,
            PosterPath = "/qNBAXBIQlnOThrVvA6mA2B5ggV6.jpg",
            Title = "Harry Potter",
            ReleaseDate = DateOnly.FromDateTime(DateTime.Now),
            Ratings = new List<RatingViewModel>
            {
              new RatingViewModel
              {
                Review = "Hello, Vlad",
                StarRating = 3
              },
              new RatingViewModel
              {
                Review = "Hello, Vlad",
                StarRating = 1
              },
              new RatingViewModel
              {
                Review = "Hello, Vlad",
                StarRating = 8
              }
            }
          },
          new()
          {
            Id = 640146,
            PosterPath = "/ngl2FKBlU4fhbdsrtdom9LVLBXw.jpg",
            Title = "The Lord of the Rings",
            ReleaseDate = DateOnly.FromDateTime(DateTime.Now),
            Ratings = new List<RatingViewModel>
            {
              new RatingViewModel
              {
                Review = "Hello, Vlad",
                StarRating = 3
              },
              new RatingViewModel
              {
                Review = "Hello, Vlad",
                StarRating = 1
              },
              new RatingViewModel
              {
                Review = "Hello, Vlad",
                StarRating = 8
              }
            }
          },
          new()
          {
            Id = 502356,
            PosterPath = "/qNBAXBIQlnOThrVvA6mA2B5ggV6.jpg",
            Title = "Harry Potter",
            ReleaseDate = DateOnly.FromDateTime(DateTime.Now),
            Ratings = new List<RatingViewModel>
            {
              new RatingViewModel
              {
                Review = "Hello, Vlad",
                StarRating = 3
              },
              new RatingViewModel
              {
                Review = "Hello, Vlad",
                StarRating = 1
              },
              new RatingViewModel
              {
                Review = "Hello, Vlad",
                StarRating = 8
              }
            }
          }
        }
      }
    );
  }

  public static async Task<List<MovieListViewModel>> GetCustomMovieLists()
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