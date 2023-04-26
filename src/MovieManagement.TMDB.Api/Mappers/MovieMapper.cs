namespace MovieManagement.TMDB.Api.Mappers;

public class MovieMapper : Profile
{
    public MovieMapper()
    {
        CreateMap<MovieDto, Movie>();
    }
}