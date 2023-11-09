using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

using Microsoft.EntityFrameworkCore;

using System.Linq;
using Happyhealth.Models;

namespace Happyhealth.Repository.CancelAppointmentRepository
{
    public class CancelAppointmentRepository : ICancelAppointmentRepository
    {
        private readonly HappyHealthDbContext _context;
        private readonly ILogger<CancelAppointmentRepository> _logger;
        private ActionResult<CancelAppointment> CancelAppointment;

        public CancelAppointmentRepository(HappyHealthDbContext context, ILogger<CancelAppointmentRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<ActionResult<IEnumerable<CancelAppointment>>> GetCancelAppointment()
        {
            _logger.LogInformation("Getting all the bookings successfully.");
            return await _context.CancelAppointment.ToListAsync();
        }

        public async Task<ActionResult<ScheduleAppointment>> GetCancelAppointment(int id, ActionResult<ScheduleAppointment> cancelAppointment)
        {
            var CancelAppointment = await _context.CancelAppointment.FindAsync(id);
            if (CancelAppointment == null)
            {
                throw new NullReferenceException("Sorry, no cancelAppointment found with this id " + id);
            }
            else
            {
                return cancelAppointment;
            }
        }

        public async Task<ActionResult<CancelAppointment>> PostCancelAppointment(CancelAppointment cancelAppointment)
        {
            _context.CancelAppointment.Add(cancelAppointment);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Booking created successfully.");

            return CancelAppointment;
        }

        public async Task<ActionResult<CancelAppointment>> DeleteBooking(int id)
        {
            var booking = await _context.CancelAppointment.FindAsync(id);
            if (booking == null)
            {
                throw new NullReferenceException("Sorry, no flight found with this id " + id);
            }
            else
            {
                _context.CancelAppointment.Remove(booking);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Booking deleted successfully.");

                return booking;
            }
        }

        public bool BookingExists(int id)
        {
            return _context.CancelAppointment.Any(e => e.user_id == id);
        }


        Task<ActionResult<IEnumerable<CancelAppointment>>> ICancelAppointmentRepository.GetCancelAppointment()
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<CancelAppointment>> ICancelAppointmentRepository.GetCancelAppointment(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<CancelAppointment>> ICancelAppointmentRepository.PostCancelAppointment(CancelAppointment cancelAppointment)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<CancelAppointment>> ICancelAppointmentRepository.DeleteCancelAppointment(int id)
        {
            throw new NotImplementedException();
        }

        bool ICancelAppointmentRepository.CancelExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}

//    public Task<ActionResult<IEnumerable<HotelReservations>>> GetHotelReservations()
//    {
//        throw new NotImplementedException();
//    }

//    public Task<ActionResult<HotelReservations>> GetHotelReservatios(int id)
//    {
//        throw new NotImplementedException();
//    }

//    public Task<ActionResult<HotelReservations>> PostHotelReservatios(HotelReservations hotelReservatios)
//    {
//        throw new NotImplementedException();
//    }

//    public Task<ActionResult<HotelReservations>> DeleteHotelReservatios(int id)
//    {
//        throw new NotImplementedException();
//    }
//}
//}