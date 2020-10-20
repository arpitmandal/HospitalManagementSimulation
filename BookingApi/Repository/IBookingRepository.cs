using BookingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApi.Repository
{
    public interface IBookingRepository
    {
        public List<Booking> GetBooking();
        public IQueryable<Booking> GetBooking(int id);
        public Booking PutBooking(int id, Booking booking);
        public void PostBooking(Booking booking);
        public IQueryable<Booking> DeleteBooking(int id);
    }
}
