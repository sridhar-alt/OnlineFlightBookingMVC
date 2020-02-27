using OnilneFlightBooking.Entity;
using OnlineFlightbooking.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlightMVC.Controllers
{
    public class FlightController : Controller
    {
        // GET: Flight
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Displayflight()
        {
            IEnumerable<FlightEntity> con = FlightRepository.ViewFlightDetails();
            return View();
        }
    }
}