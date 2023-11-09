using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Happyhealth.Models
{
    public class CancelAppointment
    {
        [Required]
        [Key]
        public int AppointmentId { get; set; }
        [ForeignKey("Users")]
        public int? user_id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Date { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Hospital { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Age { get; set; }
        [Required]
        public string Reason { get; set; }
        [Required]
        public string CancelAppointments { get; set; }

    }
}

