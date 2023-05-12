namespace AzureFunctions; 

public class MapperProfile : Profile   {
    public  MapperProfile() {
        CreateMap<RegisterUserDto, UserEntity>();
        CreateMap<UserDto, UserEntity>().ReverseMap();
    }
}