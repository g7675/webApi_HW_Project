
using entitiy;
using System.Text.Json;

namespace repository
{
    public class UserRepository
    {
        private string filePath = "..\\repository\\Users.txt";
        public User AddUser(User user)
        {
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.Id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
            return user;
        }

        public User GetUserById(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))

            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =

                    JsonSerializer.Deserialize<User>(currentUserInFile);

                    if (user.Id == id)
                        return user;
                }
            }

            return null;
        }

        public User GetUserByName(string username)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))

            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =

                    JsonSerializer.Deserialize<User>(currentUserInFile);

                    if (user.UserName == username)

                        return user;
                }
            }
            return null;
        }

        public void UpdateUser(int id, User userToUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader =
            System.IO.File.OpenText(filePath))

            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =JsonSerializer.Deserialize<User>(currentUserInFile);

                    if (user.Id == id)
                        textToReplace = currentUserInFile;
                }
            }
            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace,

                JsonSerializer.Serialize(userToUpdate));

                System.IO.File.WriteAllText(filePath, text);
            }
        }
    }
    }

