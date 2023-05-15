using MovieManagement.Database.Entities;

namespace MovieManagement.Functions; 

public class MapperProfile : Profile   {
    public  MapperProfile() {
        CreateMap<RegisterUserDto, UserEntity>();
        CreateMap<UserDto, UserEntity>().ReverseMap();
    }
}