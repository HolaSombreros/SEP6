namespace MovieManagement.Models
{
	public class MovieViewModel
	{
		public long Id { get; set; } = default!;
		public string Title { get; set; } = default!;
		public string PosterPath { get; set; } = default!;
		public DateOnly ReleaseDate { get; set; } = default!;
		public List<RatingViewModel> Ratings { get; set; } = new();
	}

	public class RatingViewModel
	{
		public string? Review { get; set; }
		public int StarRating { get; set; } = default!;
	}
}
