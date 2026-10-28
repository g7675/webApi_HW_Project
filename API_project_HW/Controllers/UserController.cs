using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.Json;
using Zxcvbn;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_project_HW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //fix: The path never changes, so it can be readonly
        readonly string filePath = "Users.txt";
        // GET: api/<UsersController>
        [HttpGet]
        public string Get()
        {
            return  "ef";
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))

            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =

                    JsonSerializer.Deserialize<User>(currentUserInFile);

                    if (user.Id == id)
                        return Ok(user);
                }
            }

            return NoContent();
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.Id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        // POST api/<UsersController>
        [HttpPost ("passwordCheck")]
        public IActionResult Post([FromBody] string password)
        {
            int result = Zxcvbn.Core.EvaluatePassword(password).Score;
            return Ok(result);
        }

        [HttpPost ("Login")]
        public IActionResult Post([FromBody] LoginUser loginUser)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))

            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =

                    JsonSerializer.Deserialize<User>(currentUserInFile);

                    if (user.UserName == loginUser.UserName && user.Password ==loginUser.Password)

                        return Ok(user);
                }
            }
            return NoContent();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User userToUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader =
            System.IO.File.OpenText(filePath))

            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =

                    JsonSerializer.Deserialize<User>(currentUserInFile);

                    if (user.Id == id)
                    {
                        textToReplace = currentUserInFile;
                        //fix: Found- break
                        break;
                    }
                }
            }
            if (textToReplace != string.Empty)
            {
                //fix: Keep the id, otherwise the updated user is saved without it
                userToUpdate.Id = id;
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace,

                JsonSerializer.Serialize(userToUpdate));

                System.IO.File.WriteAllText(filePath, text);
            }
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
