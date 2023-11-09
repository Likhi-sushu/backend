using Microsoft.AspNetCore.Mvc;
using Happyhealth.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Happyhealth.Repository.CancelAppointmentRepository
{
    public interface ICancelAppointmentRepository
    {
        Task<ActionResult<IEnumerable<CancelAppointment>>> GetCancelAppointment();
        Task<ActionResult<CancelAppointment>> GetCancelAppointment(int id);
        Task<ActionResult<CancelAppointment>> PostCancelAppointment(CancelAppointment cancelAppointment);
        Task<ActionResult<CancelAppointment>> DeleteCancelAppointment(int id);
        bool CancelExists(int id);
    }
}