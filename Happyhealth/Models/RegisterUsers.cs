using System.ComponentModel.DataAnnotations;

namespace Happyhealth.Models
{
    public class RegisterUsers
    {
        [Key]
        [Required]
        public int user_id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string DOB { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string UserType { get; set; }

    }
}
