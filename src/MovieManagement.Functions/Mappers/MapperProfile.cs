namespace MovieManagement.Functions.Mappers; 

public class MapperProfile : Profile   {
    public  MapperProfile() {
        CreateMap<RegisterUserDto, UserEntity>();
        CreateMap<MovieDto, MovieEntity>().ReverseMap();
        CreateMap<UserDto, UserEntity>().ReverseMap();
        CreateMap<RatingDto, RatingEntity>().ReverseMap();
        CreateMap<RatingSubsetDto, RatingEntity>().ReverseMap();
    }
}