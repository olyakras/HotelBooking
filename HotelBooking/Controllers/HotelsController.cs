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
    public class HotelsController : Controller
    {
        private HotelContext db = new HotelContext();

        [HttpPost]
        public ActionResult Book(Room room, Place place)
        {
            var curOrder = db.CurrentOrders.First() as CurrentOrder;
            Order order = new Order { Place = place, OrderDate = DateTime.Now, FirstDay = curOrder.FirstDay, LastDay = curOrder.LastDay, Room = room };
            db.Orders.Add(order);
            db.CurrentOrders.Remove(curOrder);
            db.SaveChanges();
            ViewBag.Message = "Бронирование завершено!";
            return RedirectToAction("Index", "Home");
        }
    // GET: Hotels/Details/5
    public ActionResult Details(int? PlaceId)
        {
            Hotel hotel = db.Hotels.FirstOrDefault(h => h.PlaceId==PlaceId);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View("Details", hotel);
        }

        // GET: Hotels/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Hotels/Create
        //// Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        //// сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Name,Country,City,Address,Rating")] Hotel hotel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Places.Add(hotel);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(hotel);
        //}

        //// GET: Hotels/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Hotel hotel = db.Hotels.Find(id);
        //    if (hotel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(hotel);
        //}

        //// POST: Hotels/Edit/5
        //// Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        //// сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name,Country,City,Address,Rating")] Hotel hotel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(hotel).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(hotel);
        //}

        //// GET: Hotels/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Hotel hotel = db.Hotels.Find(id);
        //    if (hotel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(hotel);
        //}

        //// POST: Hotels/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Hotel hotel = db.Hotels.Find(id);
        //    db.Places.Remove(hotel);
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
