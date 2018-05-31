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
    public class ActiveBooksController : Controller
    {
        private HotelContext db = new HotelContext();

        // GET: ActiveBooks
        public ActionResult Index()
        {
            foreach (var item in db.ActiveBooks)
            {
                item.Place = db.Hotels.Where(p => p.PlaceId == item.PlaceId).First();
            }
            return View(db.Orders.ToList());
        }

        // GET: ActiveBooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActiveBook activeBook = db.ActiveBooks.Find(id);
            if (activeBook == null)
            {
                return HttpNotFound();
            }
            ViewBag.Message("");
            return View(activeBook);
        }

        // POST: ActiveBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order activeBook = db.Orders.Find(id);
            db.Orders.Remove(activeBook);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
