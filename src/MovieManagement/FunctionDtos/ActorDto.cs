namespace MovieManagement.FunctionDtos; 

public class ActorDto {
    public int ActorId { get; set; }
    public List<AddMovieActorDto> Movies { get; set; } = default!;
    public int Gender { get; set; }
    public DateTime? Birthdate { get; set; }
    public string Name { get; set; } = default!;

    public ActorDto(PersonViewModel personViewModel) {
        ActorId = personViewModel.Id;
        Gender = personViewModel.Gender;
        Birthdate = personViewModel.Birthday.Equals(new DateTime(1, 1, 1)) ? null : personViewModel.Birthday;
        Name = personViewModel.Name;
        Movies = new List<AddMovieActorDto>();
        foreach (var movie in personViewModel.Credits.Cast) {
            var m = new AddMovieActorDto() {
                Title = movie.Title,
                MovieId = movie.Id,
                PosterUrl = movie.PosterUrl,
                MovieOrder = movie.Order,
                ReleaseDate = movie.ReleaseDate.Equals(new DateTime(1, 1, 1))? null : movie.ReleaseDate.ToString("yyyy-MM-dd"),
            };
            Movies.Add(m);
        }

    }
}