namespace MovieManagement.TMDB.Api.Mappers;

public class MovieMapper : Profile
{
    public MovieMapper()
    {
        CreateMap<MovieDto, Movie>().ForMember(dest=> dest.ImageUrl, opt => opt.MapFrom(src => ApiConfig.ImageUri + src.ImageUrl));
        CreateMap<MovieListDto, MovieList>();
        CreateMap<DatePeriodDto, DatePeriod>();
        CreateMap<GenreDto, Genre>();
        CreateMap<CastDto, Cast>().ForMember(dest=> dest.ImageUrl, opt => opt.MapFrom(src => ApiConfig.ImageUri + src.ImageUrl));;
        CreateMap<CrewDto, Crew>().ForMember(dest=> dest.ImageUrl, opt => opt.MapFrom(src => ApiConfig.ImageUri + src.ImageUrl));;
        CreateMap<CreditsDto, Credits>();
        CreateMap<SearchAllListDto, SearchAll>();
        CreateMap<SearchResultDto, SearchResult>();
    }
}