﻿using OnilneFlightBooking.Entity;
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
        public ActionResult SignUp(UserEntity user)
        {
            if (ModelState.IsValid)
            {
                UpdateModel<UserEntity>(user);
                UserRepository.RegisterUser(user);
                TempData["message"] = "redgistered successfull";
                return RedirectToAction("SignIn");
            }
            return View();
        }
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(FormCollection form)
        {
            if (ModelState.IsValid)
            {
                UserEntity user = new UserEntity(Request.Form["Mobile"], Request.Form["Password"]);
                int role = UserRepository.ValidateLogin(user);
                if (role == 1)
                {
                    TempData["message"] = " Admin Login successfull";
                    return RedirectToAction("UserDisplay");
                }
                else if(role==2)
                {
                    TempData["message"] = "user Login successfull";
                    return RedirectToAction("UserDisplay");
                }
                TempData["message"] = "Incorrect mobile number or password";
            }
            return View();
        }
        [HttpGet]
        public ActionResult UserDisplay()
        {
            return View();
        }
    }
}