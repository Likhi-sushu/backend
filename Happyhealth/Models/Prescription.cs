using System.Collections.Generic;

namespace Happyhealth.Models
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }

        public string PatientName { get; set; }

        // List of medications associated with this prescription
        public virtual ICollection<Medication> Medications { get; set; } = new List<Medication>();
    }

    public class Medication
    {
        public int MedicationId { get; set; }

        public string MedName { get; set; }

        public string Strength { get; set; }

        public string Dosage { get; set; }

        public string Frequency { get; set; }

        // Foreign Key for Prescription
        public int PrescriptionId { get; set; }

        // Navigation property for Prescription
        public virtual Prescription Prescription { get; set; }
    }
}
