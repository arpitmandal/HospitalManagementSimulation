using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingApi.Models;
using Microsoft.AspNetCore.Authorization;
using System.Runtime.CompilerServices;
using BookingApi.Repository;

namespace BookingApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(BookingsController));
        //private readonly simulationContext _context;

        //public BookingsController(simulationContext context)
        //{
        //    _context = context;
        //}

        private readonly IBookingRepository _bookingRepository;

        public BookingsController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
           
        }

        // GET: api/Bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBooking()
        {
            _log4net.Info("Controller of Booking appointment");
            return Ok(_bookingRepository.GetBooking());
        }

        // GET: api/Bookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            return Ok(_bookingRepository.GetBooking(id));
        }

        // PUT: api/Bookings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, Booking booking)
        {
            if (id != booking.BookingId)
            {
                return BadRequest();
            }
            _bookingRepository.PutBooking(id, booking);
            return NoContent();
        }

        // POST: api/Bookings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(Booking booking)
        {
            _bookingRepository.PostBooking(booking);

            return CreatedAtAction("GetBooking", new { id = booking.BookingId }, booking);
        }

        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Booking>> DeleteBooking(int id)
        {
            IQueryable<Booking> booking = (IQueryable<Booking>)_bookingRepository.DeleteBooking(id);
            if (booking.Count() == 0)
            {
                return NotFound();
            }

            return Ok(booking);
        }
    }
}
