
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace HotelBooking.Models
{
    public class Hotel: Place
    {
        public int Stars { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
