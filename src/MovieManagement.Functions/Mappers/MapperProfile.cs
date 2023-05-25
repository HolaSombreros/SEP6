namespace MovieManagement.Functions.Mappers; 

public class MapperProfile : Profile   {
    public  MapperProfile() {
        CreateMap<RegisterUserDto, UserEntity>();
        CreateMap<MovieDto, MovieEntity>().ReverseMap();
        CreateMap<UserDto, UserEntity>().ReverseMap();
        CreateMap<MovieRatingDto, RatingEntity>()
            .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.MovieDto.MovieId))
            .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.CreatedDate))
            .ForPath(dest => dest.UserEntity.Username, opt => opt.MapFrom(src => src.CreatedBy))
            .ReverseMap();
        CreateMap<RatingSubsetDto, RatingEntity>().ReverseMap();
        CreateMap<GenreDto, GenreEntity>().ReverseMap();
        CreateMap<MovieGenreDto, MovieGenreEntity>().ReverseMap();
        CreateMap<GenreDto, MovieGenreEntity>().ReverseMap();
        CreateMap<MovieListDto, MovieListEntity>().ReverseMap();
        CreateMap<AddMovieListDto, MovieListEntity>().ReverseMap();
        CreateMap<MovieToMovieListDto, MovieListMovieEntity>().ReverseMap();
        CreateMap<ActorDto, ActorEntity>().ReverseMap();
        CreateMap<MovieActorDto, MovieActorEntity>().ReverseMap();
    }
}