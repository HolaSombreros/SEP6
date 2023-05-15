using MovieManagement.Database.Entities;
using UserEntity = MovieManagement.Functions.Database.UserEntity;

namespace MovieManagement.Functions; 

public class MapperProfile : Profile   {
    public  MapperProfile() {
        CreateMap<RegisterUserDto, UserEntity>();
        CreateMap<UserDto, UserEntity>().ReverseMap();
    }
}