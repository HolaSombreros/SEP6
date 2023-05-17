
namespace MovieManagement.Functions.Services;
public class UserService : IUserService {

    private readonly IMapper _mapper;
    private readonly IUserRepository _repository;
    
    public UserService(IMapper mapper, IUserRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<UserDto> GetUser(LoginUserDto loginUserDto)
    {
        var user = await _repository.GetByEmail(loginUserDto.Email);
        if (!user!.Password.Equals(loginUserDto.Password)) {
            throw new Exception("Password and email don't match");
        }

        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> UpdateUser(UserDto userDto) {
        var existsWithEmail = await _repository.GetByEmail(userDto.Email);
        if (existsWithEmail != null && !existsWithEmail.UserId.Equals(userDto.UserId)) 
        {
            throw new Exception("An account with this email already exists");
        }

        var existsWithUsername = await _repository.GetByUsername(userDto.Username);
        if (existsWithUsername != null && !existsWithUsername.UserId.Equals(userDto.UserId)) 
        {
            throw new Exception("An account with this username already exists");
        }
        var user = _mapper.Map<UserEntity>(userDto);
        var userUpdated = await _repository.UpdateAsync(user);
        return _mapper.Map<UserDto>(userUpdated);
    }

    public async Task<UserDto> RegisterUser(RegisterUserDto registerUserDto)
    {
        if (await _repository.GetByEmail(registerUserDto.Email) != null) 
        {
            throw new Exception("An account with this email already exists");
        }

        if (await _repository.GetByUsername(registerUserDto.Username) != null) 
        {
            throw new Exception("An account with this username already exists");
        }
        
        var user = _mapper.Map<UserEntity>(registerUserDto);
        user.UserId = new Guid();
        user.IsDeleted = false;
        
        await _repository.AddAsync(user);
        
        var userDto = _mapper.Map<UserDto>(user);
        return userDto;
    }
}