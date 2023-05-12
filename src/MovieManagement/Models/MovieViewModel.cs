namespace MovieManagement.Models
{
	public class MovieListViewModel
	{
		public int TotalPages { get; } = default!;
		public int TotalResults { get; } = default!;
		public int Page { get; set; } = default!;
		public List<MovieViewModel> Movies { get; set; } = new();

		public MovieListViewModel(MovieList movieList)
		{
			TotalPages = movieList.TotalPages;
			TotalResults = movieList.TotalResults;
			Page = movieList.Page;

			foreach (var movie in movieList.Movies)
			{
				Movies.Add(new MovieViewModel(movie));
			}
		}

		public MovieListViewModel()
		{

		}
	}

	public class MovieViewModel
	{
		public int Id { get; set; } = default!;
		public string Title { get; set; } = default!;
		public string PosterPath { get; set; } = default!;
		public DateOnly ReleaseDate { get; set; } = default!;
		public List<RatingViewModel> Ratings { get; set; } = new();

		public MovieViewModel(Movie movie)
		{
			Id = movie.Id;
			Title = movie.Title;
			PosterPath = movie.ImageUrl;
			ReleaseDate = DateOnly.FromDateTime(movie.ReleaseDate);
			// TODO - Map ratings.
		}

		public MovieViewModel()
		{

		}
	}

	public class RatingViewModel
	{
		public string? Review { get; set; }
		public int StarRating { get; set; } = default!;
	}
}
