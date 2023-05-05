namespace MovieManagement.TMDB.Api.Mappers;

public class MovieMapper : Profile
{
    public MovieMapper()
    {
        CreateMap<MovieDto, Movie>().ForMember(dest=> dest.ImageUrl, opt => opt.MapFrom(src => ApiConfig.ImageUri + src.ImageUrl));
        CreateMap<UpcomingDto, MovieList>().ForMember(dest => dest.ListType, opt => opt.MapFrom(src => "Upcoming"));
        CreateMap<DatePeriodDto, DatePeriod>();
    }
}