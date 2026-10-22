using System.ComponentModel.DataAnnotations;

namespace API_project_HW
{
    public class LoginUser
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
