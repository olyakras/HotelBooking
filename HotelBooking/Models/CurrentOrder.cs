using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelBooking.Models
{
    public class CurrentOrder
    {
        public int CurrentOrderId { get; set; }
        [Display(Name = "Город")]
        public string City { get; set; }
        [Display(Name = "День прибытия")]
        public DateTime FirstDay { get; set; }
        [Display(Name = "День отбытия")]
        public DateTime LastDay { get; set; }
        public int PlaceId { get; set; }
        public int RoomId { get; set; }
        //public int PlaceId { get; set; }
        //public int RoomId { get; set; }
    }
}