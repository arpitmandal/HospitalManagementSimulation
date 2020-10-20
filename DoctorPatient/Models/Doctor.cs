using System;
using System.Collections.Generic;

namespace DoctorPatient.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Booking = new HashSet<Booking>();
        }

        public int DoctorId { get; set; }
        public string Dname { get; set; }
        public string Special { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
    }
}
