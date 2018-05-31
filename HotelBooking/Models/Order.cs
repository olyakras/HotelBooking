using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBooking.Models
{
    public class Order
    {
        public int Id { get; set; }
        //public int ClientId { get; set; }
        public int ClientId { get; set; }
        public int PlaceId { get; set; }
        //public int PlaceId { get; set; }
        public DateTime FirstDay { get; set; }
        public DateTime LastDay { get; set; }
        public DateTime OrderDate { get; set; }
        public int RoomId { get; set; }
    }
}