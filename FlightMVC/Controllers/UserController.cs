using System.Web.Mvc;

namespace FlightMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult SignUp()
        {
            return View();
        }
        public ActionResult SignIn()
        {
            return View();
        }
    }
}