using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Happyhealth.Models;
using Happyhealth.Repository.ScheduleAppointmentRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happyhealth.Repository.ScheduleAppointmentRepository
{
    public class ScheduleAppointmentRepository : IScheduleAppointmentRepository
    {
        private readonly HappyHealthDbContext _context;
        private readonly ILogger<ScheduleAppointmentRepository> _logger;
        //private string destination;
        //private string roomtype;

        public ActionResult<ScheduleAppointment> ScheduleAppointment { get; private set; }

        public ScheduleAppointmentRepository(HappyHealthDbContext context, ILogger<ScheduleAppointmentRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ActionResult<IEnumerable<ScheduleAppointment>>> GetAppointment()
        {
            _logger.LogInformation("Getting all the Appointment successfully.");
            return await _context.ScheduleAppointment.ToListAsync();
        }

        public async Task<ActionResult<ScheduleAppointment>> GetAppointment(int id)
        {
            var scheduleAppointment = await _context.ScheduleAppointment.FindAsync(id);
            if (scheduleAppointment == null)
            {
                throw new NullReferenceException("Sorry, no appointment found with this id " + id);
            }
            else
            {
                return scheduleAppointment;
            }
        }

        public async Task<ActionResult<ScheduleAppointment>> GetRoomsByDateAndHospital(string Date, string Hospital)
        {
            var scheduleAppointment = await _context.ScheduleAppointment.FirstOrDefaultAsync(x => x.SelectDate == Date && x.SelectHospital == Hospital);
            if (scheduleAppointment == null)
            {
                throw new NullReferenceException("Sorry, no appointment found with this Date and Hospital.");
            }
            else
            {
                return scheduleAppointment;
            }
        }

        public async Task<ActionResult<ScheduleAppointment>> PostAppointment(ScheduleAppointment appointment)
        {
            _ = _context.ScheduleAppointment.Add(appointment);
            _ = await _context.SaveChangesAsync();
            _logger.LogInformation("appointment created successfully.");
            //await HotelRoomsRepository.PostHotelRooms(HotelRooms);
            //return CreatedAtAction("GetRegisterUser", new { id = hotelRooms1.Id }, hotelRooms1);
            return ScheduleAppointment;
        }

        //private ActionResult<HotelRooms> CreatedAtAction(string v, object value, object registerUser)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<ActionResult<ScheduleAppointment>> DeleteRoom(int id)
        {
            var scheduleAppointment = await _context.ScheduleAppointment.FindAsync(id);
            if (ScheduleAppointment == null)
            {
                throw new NullReferenceException("Sorry, no Room found with this id " + id);
            }
            else
            {
                _ = _context.ScheduleAppointment.Remove(scheduleAppointment);
                _ = await _context.SaveChangesAsync();
                _logger.LogInformation("HotelRoom deleted successfully.");

                return ScheduleAppointment;
            }
        }

        public bool ScheduleAppointmentExists(int id)
        {
            return _context.ScheduleAppointment.Any(e => e.user_id == id);
        }

        public Task<ActionResult<ScheduleAppointment>> GetAppointmentByDateAndHospital(string Date, string Hospital)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<ScheduleAppointment>> DeleteAppointment(int id)
        {
            throw new NotImplementedException();
        }

        public bool AppointmentExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}

//        public Task<ActionResult<IEnumerable<ScheduleAppointment>>> GetScheduleAppointment()
//        {
//            throw new NotImplementedException();
//        }

//        public Task<ActionResult<ScheduleAppointment>> GetScheduleAppointment(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<ActionResult<ScheduleAppointment>> GetAppointmentByDateAndHospital(string Date, string Hospital)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<ActionResult<ScheduleAppointment>> PostScheduleAppointment(ScheduleAppointment bus)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<ActionResult<ScheduleAppointment>> DeleteScheduleAppointment(int id)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}