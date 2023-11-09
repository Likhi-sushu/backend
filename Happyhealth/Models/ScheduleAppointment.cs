using System.ComponentModel.DataAnnotations;

namespace Happyhealth.Models
{
    public class ScheduleAppointment
    {
        [Key]
        [Required]
        public int user_id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string DOB { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string HealthIssue { get; set; }
        [Required]
        public string SelectDoctor { get; set; }
        [Required]
        public string SelectDate { get; set; }
        [Required]
        public string SelectSlot{ get; set; }
        [Required]

        public string selectCity { get; set; }
        [Required]
   
        public string SelectHospital { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Age { get; set; }     
        public string Status { get; set; }
      
        


    }
}

