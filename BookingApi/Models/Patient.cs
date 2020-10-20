using System;
using System.Collections.Generic;

namespace BookingApi.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Booking = new HashSet<Booking>();
        }

        public int PatientId { get; set; }
        public string Pname { get; set; }
        public string Disease { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
    }
}
