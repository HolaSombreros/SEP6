namespace MovieManagement.Functions.Services; 


public class UserService : IUserService {

    private readonly IMapper _mapper;
    private readonly IUserRepository _repository;


    public UserService(IMapper mapper, IUserRepository repository) {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<UserDto> GetUser(LoginUserDto loginUserDto) {
        var user = await _repository.GetByEmail(loginUserDto.Email);
        return user!.Password.Equals(loginUserDto.Password) ? _mapper.Map<UserDto>(user) : null;
    }
    

    public async Task<UserDto> RegisterUser(RegisterUserDto registerUserDto) {
        if (await _repository.GetByEmail(registerUserDto.Email) != null)
            return null;
        var user = _mapper.Map<UserEntity>(registerUserDto);
        user.UserId = new Guid();
        user.IsDeleted = false;

        await _repository.AddAsync(user);

        var userDto = _mapper.Map<UserDto>(user);
        return userDto;
    }
}