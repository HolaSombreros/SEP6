using MovieManagement.Domain.Models.TMDB;

namespace MovieManagement.TMDB.Api.Mappers;

public class MovieMapper : Profile
{
    public MovieMapper()
    {
        CreateMap<MovieDto, Movie>().ForMember(dest=> dest.ImageUrl, opt => opt.MapFrom(src => ApiConfig.ImageUri + src.ImageUrl));
        CreateMap<MovieListDto, MovieList>();
        CreateMap<DatePeriodDto, DatePeriod>();
        CreateMap<GenreDto, Genre>();
        CreateMap<CastDto, Cast>().ForMember(dest=> dest.ImageUrl, opt => opt.MapFrom(src => ApiConfig.ImageUri + src.ImageUrl));
        CreateMap<CrewDto, Crew>().ForMember(dest=> dest.ImageUrl, opt => opt.MapFrom(src => ApiConfig.ImageUri + src.ImageUrl));
        CreateMap<CreditsDto, Credits>();
        CreateMap<PersonDto, Person>().ForMember(dest => dest.ImageUrl,
                opt => opt.MapFrom(src => src.ImageUrl == null ? null : ApiConfig.ImageUri + src.ImageUrl))
            .ForMember(dest => dest.DeathDay, opt => opt.MapFrom(src => src.DeathDay == null ? null : src.DeathDay));
    }
}