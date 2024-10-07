using c_sharp.Contracts;
using c_sharp.Models.User;

namespace c_sharp.Service.UserService;
    public class UserService
    {
        private readonly IUserContract _userRepository;

        public UserService(IUserContract userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> RegisterUser(CreateUserDto createUser)
        {
            return await _userRepository.CreateUser(createUser);
        }

        public async Task<User?> Login(LoginUserDto loginDto)
        {
            var user = await _userRepository.GetUserByEmail(loginDto.Email);
            var hash = BCrypt.Net.BCrypt.EnhancedHashPassword(loginDto.Password);
            Console.WriteLine($"Hash: {hash}");
                Console.WriteLine($"SERVICE: {loginDto.Password} {user.HashPassword}");
            if (user != null && BCrypt.Net.BCrypt.EnhancedVerify(loginDto.Password, user.HashPassword))
            {
                return user;
            }
            
            return null;
        }
        public async Task<User> GetUserByEmail(string email)
        {
            return await _userRepository.GetUserByEmail(email);
        }
    }

