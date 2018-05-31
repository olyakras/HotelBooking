using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelBooking.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        [Display(Name = "Место")]
        //public int PlaceId { get; set; }
        public Client Client { get; set; }
        //public int ClientId { get; set; }
        [Display(Name = "Рейтинг")]
        public int Rating { get; set; }
        [Display(Name = "Дата")]
        public DateTime Date { get; set; }
        [Display(Name = "Отзыв")]
        public string Comment { get; set; }
    }
}