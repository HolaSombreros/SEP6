using MovieManagement.Models;

namespace MovieManagement.Data;

public class DummyData
{
  public static async Task<IEnumerable<MovieViewModel>> GetMovies()
  {
    return await Task.FromResult(
      new List<MovieViewModel>()
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
    );
  }
}