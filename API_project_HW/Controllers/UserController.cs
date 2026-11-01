using entitiy;
using Microsoft.AspNetCore.Mvc;
using service;
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
        UserService userService = new UserService();
        
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
            User user = userService.GetUserById(id);
            if (user == null) return NoContent();
            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            User added = userService.AddUser(user);
            if (added == null) return BadRequest();
            return Ok(added);
        }

        // POST api/<UsersController>
        [HttpPost ("passwordCheck")]
        public IActionResult Post([FromBody] string password)
        {
            return Ok(userService.CheckPasswordStrength(password));
        }

        [HttpPost ("Login")]
        public IActionResult Post([FromBody] LoginUser loginUser)
        {
            User user = userService.Login(loginUser);
            if(user== null) return NoContent();
            return Ok(user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User userToUpdate)
        {
            userService.UserUpdate(id, userToUpdate);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
