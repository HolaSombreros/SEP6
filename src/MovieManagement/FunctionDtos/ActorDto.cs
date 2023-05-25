namespace MovieManagement.FunctionDtos; 

public class ActorDto {
    public int ActorId { get; set; }
    public List<AddMovieActorDto> Movies { get; set; } = default!;
    public int Gender { get; set; }
    public DateTime Birthdate { get; set; }
    public string Name { get; set; } = default!;

    public ActorDto(PersonViewModel personViewModel) {
        ActorId = personViewModel.Id;
        Gender = personViewModel.Gender;
        Birthdate = personViewModel.Birthday;
        Name = personViewModel.Name;
        foreach (var movie in personViewModel.Credits.Cast) {
            Movies.Add(new AddMovieActorDto() {
                Title = movie.Title,
                MovieId = movie.Id,
                PosterUrl = movie.PosterUrl, 
                Order = movie.Order,
                ReleaseDate = movie.ReleaseDate.ToString("yyyy-MM-dd")

            });
        }

    }
}