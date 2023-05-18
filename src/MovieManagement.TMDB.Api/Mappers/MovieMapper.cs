namespace MovieManagement.TMDB.Api.Mappers;

public class MovieMapper : Profile
{
    public MovieMapper()
    {
        CreateMap<MovieDto, Movie>().ForMember(dest=> dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl == null ? null : ApiConfig.ImageUri + src.ImageUrl));
        CreateMap<MovieListDto, MovieList>().ForMember(dest => dest.ListType, opt => opt.MapFrom(src => "Upcoming"));
        CreateMap<DatePeriodDto, DatePeriod>();
        CreateMap<GenreDto, Genre>();
        CreateMap<CastDto, Cast>().ForMember(dest=> dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl == null ? null : ApiConfig.ImageUri + src.ImageUrl))
            .ForMember(dest => dest.ReleaseDate,
                opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.ReleaseDate) ? null : src.ReleaseDate));;
        CreateMap<CrewDto, Crew>().ForMember(dest=> dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl == null ? null : ApiConfig.ImageUri + src.ImageUrl))
            .ForMember(dest => dest.ReleaseDate,
                opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.ReleaseDate) ? null : src.ReleaseDate))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => string.Equals(src.Job, Role.DIRECTOR.ToString(), StringComparison.OrdinalIgnoreCase) ? Role.DIRECTOR : Role.OTHER));
        CreateMap<CreditsDto, Credits>();
        CreateMap<ProductionCompanyDto, ProductionCompany>().ForMember(dest=> dest.LogoPath, opt => opt.MapFrom(src => src.LogoPath == null ? null : ApiConfig.ImageUri + src.LogoPath));;
        CreateMap<ProductionCountryDto, ProductionCountry>();
        CreateMap<SpokenLanguageDto, SpokenLanguage>();
        CreateMap<SearchAllListDto, SearchAll>().ForMember(dest => dest.MovieResults, opt => opt.Ignore())
            .ForMember(dest => dest.PersonResults, opt => opt.Ignore());
        CreateMap<SearchResultDto, SearchMovieResult>()
            .ForMember(dest => dest.PosterPath,
                opt => opt.MapFrom(src => src.PosterPath == null ? null : ApiConfig.ImageUri + src.PosterPath))
            .ForMember(dest => dest.ReleaseDate,
                opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.ReleaseDate) ? null : src.ReleaseDate));
        CreateMap<SearchResultDto, SearchPersonResult>().ForMember(dest => dest.ProfilePath,
            opt => opt.MapFrom(src => src.ProfilePath == null ? null : ApiConfig.ImageUri + src.ProfilePath));
        CreateMap<PersonDto, Person>().ForMember(dest => dest.ImageUrl,
                opt => opt.MapFrom(src => src.ImageUrl == null ? null : ApiConfig.ImageUri + src.ImageUrl))
            .ForMember(dest => dest.DeathDay, opt => opt.MapFrom(src => src.DeathDay == null ? null : src.DeathDay));
    }
}