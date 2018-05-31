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
    public class RoomsController : Controller
    {
        private HotelContext db = new HotelContext();

        // GET: Rooms
        //public ActionResult Index(int id)
        //{
        //    var rooms = db.Rooms.Where(r => r.Place.PlaceId == id).ToList();
        //    foreach (var room in rooms)
        //    {
        //        var curOrder = db.CurrentOrders.First() as CurrentOrder;
        //        var ordersCount = db.Orders.Where(o => o.RoomId == id).Count();
        //        if (ordersCount == room.Count) rooms.Remove(room);
        //    }
        //    return View(rooms);
        //}

        //public ActionResult Book(int id)
        //{
        //    Room room = db.Rooms.Find(id);
        //    if (room == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    var curOrder = db.CurrentOrders.First() as CurrentOrder;
        //    Order order = new Order { PlaceId = room.PlaceId, OrderDate = DateTime.Now, FirstDay = curOrder.FirstDay, LastDay = curOrder.LastDay, RoomId = id };
        //    db.Orders.Add(order);
        //    db.CurrentOrders.Remove(curOrder);
        //    db.SaveChanges();
        //    ViewBag.Message = "Бронирование завершено!";
        //    return RedirectToAction("Index", "Home");
        //}

        // GET: Rooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // GET: Rooms/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Rooms/Create
        //// Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        //// сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,PlaceId,Price,Count,Category,ComfortType")] Room room)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Rooms.Add(room);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(room);
        //}

        //// GET: Rooms/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Room room = db.Rooms.Find(id);
        //    if (room == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(room);
        //}

        //// POST: Rooms/Edit/5
        //// Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        //// сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,PlaceId,Price,Count,Category,ComfortType")] Room room)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(room).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(room);
        //}

        //// GET: Rooms/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Room room = db.Rooms.Find(id);
        //    if (room == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(room);
        //}

        //// POST: Rooms/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Room room = db.Rooms.Find(id);
        //    db.Rooms.Remove(room);
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
