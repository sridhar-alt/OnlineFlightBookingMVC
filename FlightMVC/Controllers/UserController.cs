﻿using OnilneFlightBooking.Entity;
using System.Web.Mvc;
using OnlineFlightbooking.DAL;
using System.Collections.Generic;
using System;

namespace FlightMVC.Controllers
{
    [HandleError]
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
            try
            {
                IEnumerable<UserEntity> con = UserRepository.RegisterUser();
                return View();

            }
            catch (Exception ex)
            {
                return View("Error");
               
            }
           
        }
        [HttpPost]
        public ActionResult SignUp(UserEntity user)
        {
            if (ModelState.IsValid)
            {
                UpdateModel<UserEntity>(user);
                UserRepository.RegisterUser(user);
                ViewBag.message = "registered successfull..";
                return RedirectToAction("SignIn");
            }
            return View();
        }
        [HttpGet]
        [CustomeError]
        public ActionResult SignIn()
        {
            return View();
            throw new Exception("Error have been occured..");
        }
        //[HttpPost]
        //public ActionResult SignIn(FormCollection form)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        UserEntity user = new UserEntity(Request.Form["Mobile"], Request.Form["Password"]);
        //        int role = UserRepository.ValidateLogin(user);
        //        if (role == 1)
        //        {
        //            TempData["message"] = " Admin Login successfull";
        //            return RedirectToAction("UserDisplay");
        //        }
        //        else if(role==2)
        //        {
        //            TempData["message"] = "user Login successfull";
        //            return RedirectToAction("UserDisplay");
        //        }
        //        TempData["message"] = "Incorrect mobile number or password";
        //    }
        //    return View();
        //}
        [HttpGet]
        public ActionResult UserDisplay()
        {
            return View();
        }
    }
}