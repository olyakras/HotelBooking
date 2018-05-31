using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelBooking.Models;

namespace HotelBooking.Controllers
{
    public class PlacesController : Controller
    {
        private HotelContext db = new HotelContext();
        private List<Place> chosenPlaces;
        // GET: Places
        public ActionResult Index()
        {
            var currentOrder = db.CurrentOrders.First();
            var places = db.Places.Where(p => p.City.ToUpper()==currentOrder.City.ToUpper()).ToList();
            var orders = db.Orders.Where(p => p.FirstDay <= currentOrder.FirstDay && p.LastDay >= currentOrder.LastDay).ToList();
            if (places != null)
                if (orders != null)
                {
                    foreach (var place in places)
                    {
                        foreach (var order in orders)
                        {
                            if (place.PlaceId == order.PlaceId)
                            {
                                var hotels = db.Hotels.Where(h => h.City.ToUpper() == currentOrder.City.ToUpper()).ToList();
                                var hotelPlace = place as Hotel;
                                if (hotels.Contains(hotelPlace))
                                {
                                    hotelPlace = hotels.Find(h => h.PlaceId == place.PlaceId);
                                    var rooms = db.Rooms.Where(r => r.PlaceId == hotelPlace.PlaceId).ToList();
                                    foreach (var room in rooms)
                                    {
                                        if (room.RoomId == order.RoomId)
                                        {
                                            room.Count--;
                                            if (room.Count == 0) rooms.Remove(room);
                                        }
                                    }
                                    if (rooms == null)
                                        places.Remove(place);
                                }
                                else
                                {
                                    places.Remove(place);
                                    break;
                                }
                                    
                            }
                        }
                    }
                    chosenPlaces = new List<Place>();
                    chosenPlaces = places;
                    return View(places);
                }                
                else {
                    chosenPlaces = new List<Place>();
                    chosenPlaces = places;
                    return View(places); }
            else
            {
                ViewBag.Message("По таким параметрамничего не найдено, выберите дргуие");
                return RedirectToAction("Create", "CurrentOrder");
            }
        }

        public ActionResult GetIndex()
        {
            return View(chosenPlaces);
        }

        // GET: Places/Details/5
        public ActionResult Details(int? id)
        {
            Place place = db.Places.FirstOrDefault(p => p.PlaceId==id);
            if (place == null)
            {
                return HttpNotFound();
            }
            if (db.Hotels.FirstOrDefault(h => h.PlaceId==id)==null)
            { return RedirectToAction("Details", "Flats", new { Placeid = id }); }
            else
            { return RedirectToAction("Details", "Hotels", new { PlaceId = id }); }
        }

        // GET: Places/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Places/Create
        //// Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        //// сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Name,Country,City,Address,Rating")] Place place)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Places.Add(place);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(place);
        //}

        //// GET: Places/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Place place = db.Places.Find(id);
        //    if (place == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(place);
        //}

        //// POST: Places/Edit/5
        //// Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        //// сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name,Country,City,Address,Rating")] Place place)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(place).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(place);
        //}

        //// GET: Places/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Place place = db.Places.Find(id);
        //    if (place == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(place);
        //}

        //// POST: Places/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Place place = db.Places.Find(id);
        //    db.Places.Remove(place);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
