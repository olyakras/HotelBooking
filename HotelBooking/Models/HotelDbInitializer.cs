using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HotelBooking.Models
{
    public class HotelDbInitializer: DropCreateDatabaseAlways<HotelContext>
    {
            protected override void Seed(HotelContext db)
            {
            var rooms1 = new List<Room>
            {
                new Room { Price=1000, Count=10, Category="SNGL", ComfortType="Standart"},
                new Room { Price=2000, Count=1, Category="SNGL", ComfortType="APT"}
            };
            var rooms2 = new List<Room>
            {
                new Room { Price=5000, Count=5, Category="DBL", ComfortType="Suit"},
                new Room { Price=3000, Count=2, Category="TWIN", ComfortType="Standart"},
                new Room { Price=2000, Count=1, Category="SNGL", ComfortType="APT"}
            };
            var rooms3 = new List<Room>
            {
                new Room { Price=10000, Count=2, Category="SNGL", ComfortType="King Suit"},
                new Room { Price=7000, Count=2, Category="3 ADL", ComfortType="Standart"}
            }; ;
            var client1 = new Client { Email = "rrrrr@gmail.com" };
            var client2 = new Client { Email = "aaaaaaa@gmail.com" };
            var client3 = new Client { Email = "fff@gmail.com" };
            var client4 = new Client { Email = "g4h3@gmail.com" };

            var reviews1 = new List<Review>
            {
                new Review{ Date= new DateTime(2017,3, 20), Rating=4, Comment="aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", Client=client1},
                new Review{ Date=new DateTime(2015,4, 30), Rating=2, Comment="ghjsflkdlfajf", Client=client3},
                new Review{ Date=new DateTime(2016,6, 19), Rating=3, Comment="ah;ah;gafk", Client=client2},
                new Review{ Date=new DateTime(2013,10, 2), Rating=5, Comment="sags;kadksjhkjashk", Client=client4}
            };

            var reviews2 = new List<Review>
            {
                new Review{ Date=new DateTime(2014,11, 3), Rating=3, Comment="aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", Client=client2},
                new Review{ Date=new DateTime(2016,12, 4), Rating=5, Comment="ghjsflkdlfajf", Client=client3}
            };
            var reviews3 = new List<Review>
            {
                new Review{ Date=new DateTime(2019,1, 24), Rating=4, Comment="aoofha;hjkfkjae/", Client=client1}
            };
            var reviews4 = new List<Review>
            {
                new Review{ Date=new DateTime(2015,2, 11), Rating=4, Comment="ghjsflkdlfajf", Client=client1},
                new Review{ Date=new DateTime(2016,4, 21), Rating=5, Comment="ah;ah;gafk", Client=client2},
                new Review{ Date=new DateTime(2017,8, 16), Rating=5, Comment="sags;kadksjhkjashk", Client=client3},
            };

            var hotels = new List<Hotel>
            {
             new Hotel { City="Moscow", Address="aaaaa", Country="Russia", Name="Paris", Rating=4.5, Stars=2, Rooms=rooms3, Reviews=reviews1 },
             new Hotel { City="Moscow", Address="bbbbb", Country="Russia", Name="London", Rating=4, Stars=3, Rooms=rooms1, Reviews=reviews2 },
             new Hotel { City="Paris", Address="ccccccc", Country="France", Name="Moscow", Rating=4.9, Stars=4, Rooms=rooms2, Reviews=reviews3 }
            };
            var flats = new List<Flat> { new Flat { City="Moscow", Address="ddd", Country="Russia", Beds=3, Price=10000, Rating=3.5, Rooms=4, Square=100, TypeOfRenovation="Е", Name="Дубровка", Reviews=reviews4},
             new Flat { City="London", Address="eeeeeeeeee", Country="Great Britain", Beds=2, Price=5000, Rating=4, Rooms=2, Square=70, TypeOfRenovation="Е", Name="Дубровка мини", Reviews=null}
            };

            db.Clients.AddRange(new List<Client> { client1, client2, client3, client4 });
            db.Reviews.AddRange(reviews1);
            db.Reviews.AddRange(reviews2);
            db.Reviews.AddRange(reviews3);
            db.Reviews.AddRange(reviews4);
            db.Rooms.AddRange(rooms1);
            db.Rooms.AddRange(rooms2);
            db.Rooms.AddRange(rooms3);
            db.Hotels.AddRange(hotels);
            db.Flats.AddRange(flats);
            db.Places.AddRange(hotels);
            db.Places.AddRange(flats);

            foreach (var hotel in hotels)
            {

            }
                base.Seed(db);
            }
    }
}