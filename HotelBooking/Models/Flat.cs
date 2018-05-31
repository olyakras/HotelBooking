using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace HotelBooking.Models
{
    public class Flat: Place
    {
        [Display(Name = "Цена за сутки")]
        public int Price { get; set; }
        [Display(Name = "Количество комнат")]
        public int Rooms { get; set; }
        [Display(Name = "Количество кроватей")]
        public int Beds { get; set; }
        [Display(Name = "Тип ремонта")]
        public string TypeOfRenovation { get; set; }
        [Display(Name = "Площадь")]
        public double Square { get; set; }

    }
}