using BookingApi.Models;
using BookingApi.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingNUnit
{
    public class Tests
    {
        public List<Booking> obj1 = new List<Booking>();

        //Simulation_dbContext xx = new Simulation_dbContext();
        // obj2 = new BookingesController();

        IQueryable<Booking> cdata;
        Mock<DbSet<Booking>> mockSet;
        Mock<simulationContext> Bookingcontextmock;
        [SetUp]
        public void Setup()
        {

            obj1 = new List<Booking>()
            {
                new Booking{ BookingId=4,DoctorId=2,PatientId=101,DateOfbooking=new DateTime(2020,02,02)}
            };
            cdata = obj1.AsQueryable();
            mockSet = new Mock<DbSet<Booking>>();
            mockSet.As<IQueryable<Booking>>().Setup(m => m.Provider).Returns(cdata.Provider);
            mockSet.As<IQueryable<Booking>>().Setup(m => m.Expression).Returns(cdata.Expression);
            mockSet.As<IQueryable<Booking>>().Setup(m => m.ElementType).Returns(cdata.ElementType);
            mockSet.As<IQueryable<Booking>>().Setup(m => m.GetEnumerator()).Returns(cdata.GetEnumerator());
            var p = new DbContextOptions<simulationContext>();
            Bookingcontextmock = new Mock<simulationContext>(p);
            Bookingcontextmock.Setup(x => x.Booking).Returns(mockSet.Object);

        }




        [Test]
        public void Test1()
        {
            var booking = new BookingRepository(Bookingcontextmock.Object);
            var book = booking.GetBooking(4);
            Assert.AreEqual(1, book.Count());
        }



        [Test]
        public void Test2()
        {
            var booking = new BookingRepository(Bookingcontextmock.Object);
            var x = booking.DeleteBooking(1);
            Assert.IsNotNull(x);
        }
    }
}