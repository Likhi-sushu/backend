using Microsoft.AspNetCore.Mvc;
using Happyhealth.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Happyhealth.Repository.ScheduleAppointmentRepository
{
    public interface IScheduleAppointmentRepository
    {
        Task<ActionResult<IEnumerable<ScheduleAppointment>>> GetAppointment();
        Task<ActionResult<ScheduleAppointment>> GetAppointment(int id);
        Task<ActionResult<ScheduleAppointment>> GetAppointmentByDateAndHospital(string Date, string Hospital);
        Task<ActionResult<ScheduleAppointment>> PostAppointment(ScheduleAppointment id);
        Task<ActionResult<ScheduleAppointment>> DeleteAppointment(int id);
        bool AppointmentExists(int id);
    }
}