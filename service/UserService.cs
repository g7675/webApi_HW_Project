using entitiy;
using repository;

namespace service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;
        public UserService(IUserRepository repositor)
        {
            repository = repositor;
        }
        
        public User GetUserById(int id)
        {
            return repository.GetUserById(id);
        }

        public User AddUser(User user)
        {
            if (!ValidUser(user)) return null;
            return repository.AddUser(user);
        }

        public bool UserUpdate(int id, User user)
        {
            if (!ValidUser(user)) return false;
            repository.UpdateUser(id, user);
            return true;
        }

        public User Login(LoginUser loginUser)
        {
            User user = repository.GetUserByName(loginUser.UserName);
            //What happens when no user has this UserName? GetUserByName returns null, and the next line would crash
            if (user.Password == loginUser.Password)
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

        private bool ValidUser(User user)
        {
            if (!(user.Name != null && user.Password != null && user.LastName != null && user.UserName != null)) return false;
            if (CheckPasswordStrength(user.Password) < 3) return false;
            return true;
        }
    }
}
