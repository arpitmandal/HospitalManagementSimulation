using System;
using System.Collections.Generic;

namespace BookingApi.Models
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
