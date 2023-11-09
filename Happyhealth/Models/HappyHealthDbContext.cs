using Happyhealth.Models;
using Microsoft.EntityFrameworkCore;
// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Happyhealth
{
    public class HappyHealthDbContext : DbContext
    {
        internal object RegisterUsers;


        public HappyHealthDbContext(DbContextOptions<HappyHealthDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RegisterUsers> Users { get; set; }
        public virtual DbSet<ScheduleAppointment> ScheduleAppointment { get; set; }
        public virtual DbSet<CancelAppointment> CancelAppointment { get; set; }
        public DbSet<Happyhealth.Models.Doctor> Doctor { get; set; }
        public DbSet<Happyhealth.Models.patient_report> patient_report { get; set; }
        public DbSet<Happyhealth.Models.Prescription> Prescription { get; set; }
        public DbSet<Happyhealth.Models.Medication> Medication { get; set; }
        public DbSet<Happyhealth.Models.prescribe> prescribe { get; set; }

    }
}