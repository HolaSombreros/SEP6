namespace MovieManagement.TMDB.Api.Mappers;

public class MovieMapper : Profile
{
    public MovieMapper()
    {
        CreateMap<MovieDto, Movie>().ForMember(dest=> dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl == null ? null : ApiConfig.ImageUri + src.ImageUrl));
        CreateMap<MovieListDto, MovieList>().ForMember(dest => dest.ListType, opt => opt.MapFrom(src => "Upcoming"));
        CreateMap<DatePeriodDto, DatePeriod>();
        CreateMap<GenreDto, Genre>();
        CreateMap<CastDto, Cast>().ForMember(dest=> dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl == null ? null : ApiConfig.ImageUri + src.ImageUrl));
        CreateMap<CrewDto, Crew>().ForMember(dest=> dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl == null ? null : ApiConfig.ImageUri + src.ImageUrl))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => string.Equals(src.Job, Role.DIRECTOR.ToString(), StringComparison.OrdinalIgnoreCase) ? Role.DIRECTOR : Role.OTHER));
        CreateMap<CreditsDto, Credits>();
        CreateMap<ProductionCompanyDto, ProductionCompany>().ForMember(dest=> dest.LogoPath, opt => opt.MapFrom(src => src.LogoPath == null ? null : ApiConfig.ImageUri + src.LogoPath));;
        CreateMap<ProductionCountryDto, ProductionCountry>();
        CreateMap<SpokenLanguageDto, SpokenLanguage>();
    }
}