using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelBooking.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return Redirect("/CurrentOrders/Create");
        }

    }
}