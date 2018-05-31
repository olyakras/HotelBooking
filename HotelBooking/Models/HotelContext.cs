using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HotelBooking.Models
{
    public class HotelContext : DbContext
    {
        public DbSet<Place> Places { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CurrentOrder> CurrentOrders { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ActiveBook> ActiveBooks { get; set; }
    }
}