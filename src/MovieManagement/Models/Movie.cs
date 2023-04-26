namespace MovieManagement.Models
{
	public class Movie
	{
		public long Id { get; set; }
		public string Title { get; set; }
		public string PosterPath { get; set; }
		public List<int> GenreIds { get; set; } = new();
		public List<Rating> Ratings { get; set; } = new();
	}

	public class Rating
	{
		public string Review { get; set; }
		public int StarRating { get; set; }
	}
}
