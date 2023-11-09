using System.ComponentModel.DataAnnotations;

namespace Happyhealth.Models
{
    public class Doctor
    {
       
        [Key]
        [Required]
        public int Id { get; set; }
            public string Name { get; set; }
           public string Photo { get; set; }

          public string Speciality { get; set; }
           public string Experience { get; set; }
           public string Availability { get; set; }
        public string Patientreviews { get; set; }


    }
}
