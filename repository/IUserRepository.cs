using entitiy;

namespace repository
{
    public interface IUserRepository
    {
        User AddUser(User user);
        User GetUserById(int id);
        User GetUserByName(string username);
        void UpdateUser(int id, User userToUpdate);
    }
}