using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBooking.Models
{
    public class ActiveBook: Order
    {
        public Place Place { get; set; }
        public Room Room { get; set; }
        public bool fl { get; set; }
    }
}