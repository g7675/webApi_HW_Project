using System.ComponentModel.DataAnnotations;

namespace API_project_HW
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
}
