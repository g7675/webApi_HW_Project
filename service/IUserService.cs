using entitiy;

namespace service
{
    public interface IUserService
    {
        User AddUser(User user);
        int CheckPasswordStrength(string password);
        User GetUserById(int id);
        User Login(LoginUser loginUser);
        bool UserUpdate(int id, User user);
    }
}