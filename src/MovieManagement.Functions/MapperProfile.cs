namespace MovieManagement.Functions; 

public class MapperProfile : Profile   {
    public  MapperProfile() {
        CreateMap<RegisterUserDto, UserEntity>();
        CreateMap<UserDto, UserEntity>().ReverseMap();
        CreateMap<RatingDto, RatingEntity>().ReverseMap();
    }
}