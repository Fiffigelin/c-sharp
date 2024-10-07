using c_sharp.Models.User;

namespace c_sharp.Contracts;

public interface IUserContract
{
    Task<User> CreateUser(CreateUserDto createUser);
    Task<User> GetUserByEmail(string email);
    Task<bool> VerifyUserPassword(LoginUserDto loginUser);
}