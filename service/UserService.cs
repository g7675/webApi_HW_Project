using entitiy;
using repository;

namespace service
{
    public class UserService
    {
        UserRepository repository = new UserRepository();
        public User GetUserById(int id)
        {
            return repository.GetUserById(id);
        }

        public User AddUser(User user)
        {
            return repository.AddUser(user);
        }

        public void UserUpdate(int id , User user)
        {
            repository.UpdateUser(id, user);
        }

        public User Login(LoginUser loginUser)
        {
            User user = repository.GetUserByName(loginUser.UserName);
            if(user.Password == loginUser.Password)
            {
                return user;
            }
            return null;
        }

        public int CheckPasswordStrength(string password) 
        {
            int result = Zxcvbn.Core.EvaluatePassword(password).Score;
            return result;
        }
    }
}
