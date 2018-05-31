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
    public class CurrentOrdersController : Controller
    {
        private HotelContext db = new HotelContext();

        // GET: CurrentOrders/Create


        public ActionResult Create()
        {
            return View();
        }

        // POST: CurrentOrders/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Country,City,FirstDay,LastDay")] CurrentOrder currentOrder)
        {
            if (ModelState.IsValid)
            {
                if (db.CurrentOrders != null)
                {
                    db.CurrentOrders.Remove(db.CurrentOrders.First());
                    db.SaveChanges();
                }
                db.CurrentOrders.Add(currentOrder);
                db.SaveChanges();
                return RedirectToAction("Index", "Places");
            }

            return ViewBag.Message("Ошибка");
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Country,City,FirstDay,LastDay")] CurrentOrder currentOrder)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(currentOrder).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(currentOrder);
        //}

        //// GET: CurrentOrders/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CurrentOrder currentOrder = db.CurrentOrders.Find(id);
        //    if (currentOrder == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(currentOrder);
        //}

        //// POST: CurrentOrders/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    CurrentOrder currentOrder = db.CurrentOrders.Find(id);
        //    db.CurrentOrders.Remove(currentOrder);
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
