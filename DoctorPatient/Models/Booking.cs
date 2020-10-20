using System;
using System.Collections.Generic;

namespace DoctorPatient.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public DateTime? DateOfbooking { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
