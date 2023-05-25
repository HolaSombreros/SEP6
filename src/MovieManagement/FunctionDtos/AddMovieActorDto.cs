﻿namespace MovieManagement.FunctionDtos; 

public class AddMovieActorDto {
    public int MovieId { get; set; }
    public int Order { get; set; }
    public string? Title { get; set; }
    public string? PosterUrl { get; set; }
    public string? ReleaseDate { get; set; }
}