using BookingApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApi.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly simulationContext _context;

        public BookingRepository(simulationContext context)
        {
            _context = context;
        }

        public IQueryable<Booking> DeleteBooking(int id)
        {
            IQueryable<Booking> bookings = _context.Booking.Where(a => a.BookingId == id);
            _context.Booking.Remove(bookings.FirstOrDefault());
            _context.SaveChangesAsync();
            return bookings;
        }

      

        public List<Booking> GetBooking()
        {
            return _context.Booking.ToList();
        }

        public IQueryable<Booking> GetBooking(int id)
        {
            return _context.Booking.Where(a => a.BookingId == id);
        }

        public void PostBooking(Booking booking)
        {
            _context.Booking.Add(booking);
            _context.SaveChangesAsync();
        }

        public Booking PutBooking(int id, Booking booking)
        {
            _context.Entry(booking).State = EntityState.Modified;
            _context.SaveChangesAsync();
            return booking;
        }
    }
}
