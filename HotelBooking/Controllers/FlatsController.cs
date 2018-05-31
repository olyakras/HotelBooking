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
    public class FlatsController : Controller
    {
        private HotelContext db = new HotelContext();

        // GET: Flats
        //public ActionResult Index()
        //{
        //    return View(db.Places.ToList());
        //}

        // GET: Flats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flat flat = db.Flats.Find(id);
            if (flat == null)
            {
                return HttpNotFound();
            }
            flat.Reviews = db.Reviews.Where(r => r.PlaceId == flat.PlaceId).ToList();
            foreach (var item in flat.Reviews)
            {
                item.Client = db.Clients.Where(c=> c.ClientId==item.ClientId).First();
            }
            return View(flat);
        }

        public ActionResult Book(Flat flat)
        {
            if (flat == null)
            {
                return HttpNotFound();
            }
            var curOrder = db.CurrentOrders.First() as CurrentOrder;
            Order order = new Order { PlaceId = flat.PlaceId, OrderDate = DateTime.Now, FirstDay = curOrder.FirstDay, LastDay = curOrder.LastDay, RoomId = -1 };
            db.Orders.Add(order);
            var activeOrder = order as ActiveBook;
            db.ActiveBooks.Add(activeOrder);
            db.CurrentOrders.Remove(curOrder);
            db.SaveChanges();
            ViewBag.Message = "Бронирование завершено!";
            return RedirectToAction("Index", "Home");
        }
        //// GET: Flats/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Flats/Create
        //// Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        //// сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "PlaceId,Name,Country,City,Address,Rating,Price,Rooms,Beds,TypeOfRenovation,Square")] Flat flat)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Places.Add(flat);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(flat);
        //}

        //// GET: Flats/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Flat flat = db.Flats.Find(id);
        //    if (flat == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(flat);
        //}

        //// POST: Flats/Edit/5
        //// Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        //// сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "PlaceId,Name,Country,City,Address,Rating,Price,Rooms,Beds,TypeOfRenovation,Square")] Flat flat)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(flat).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(flat);
        //}

        //// GET: Flats/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Flat flat = db.Flats.Find(id);
        //    if (flat == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(flat);
        //}

        //// POST: Flats/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Flat flat = db.Flats.Find(id);
        //    db.Places.Remove(flat);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
