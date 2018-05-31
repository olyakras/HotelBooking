using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace HotelBooking.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        //public int PlaceId { get; set; }
        [Display(Name = "Цена за сутки")]
        public int Price { get; set; }
        public int Count { get; set; }
        [Display(Name = "Вместимость номера")]
        public string Category { get; set; }
        [Display(Name = "Уровень комфорта")]
        public string ComfortType { get; set; }

    }
}