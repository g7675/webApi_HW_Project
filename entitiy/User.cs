using System.ComponentModel.DataAnnotations;

namespace entitiy
{
    public class User
    {
        [EmailAddress]
        public string UserName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int Id { get; set; }

    }

    public class LoginUser
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
