using OnilneFlightBooking.Entity;
using System.Web.Mvc;
using OnlineFlightbooking.DAL;

namespace FlightMVC.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        // GET: User
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp( UserEntity user)
        {
            if (ModelState.IsValid)
            {
                UpdateModel<UserEntity>(user);
                //UserRepository.RegisterUser(user);
                TempData["message"] = "Signup successfull";
                return RedirectToAction("SignIn");
            }
            return View();
        }
        public ActionResult SignIn()
        {
            return View();
        }
    }
}