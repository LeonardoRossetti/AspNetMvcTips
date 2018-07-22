using AutomatedTellerMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutomatedTellerMachine.Controllers
{
    public class CheckingAccountController : Controller
    {
        // GET: CheckingAccount
        public ActionResult Index()
        {
            return View();
        }

        // GET: CheckingAccount/Details
        public ActionResult Details()
        {
            var checkingAccount = new CheckingAccount
            {
                Id = 1,
                AccountNumber = "000001257",
                FirstName = "Leonardo",
                LastName = "Rossetti",
                Balance = 500
            };
            return View(checkingAccount);
        }

        // GET: CheckingAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CheckingAccount/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CheckingAccount/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CheckingAccount/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CheckingAccount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CheckingAccount/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // eg: /greetings/bye
        // and /greetings because of the Optional modifier,
        // but not /greetings/see-you-tomorrow because of the maxlength(3) constraint.
        [Route("greetings/{message:maxlength(3)?}")]
        public ActionResult Greet(string message)
        {
            return Content("Great: " + message);
        }

        [Route("greetings/{message?}")]
        public ActionResult GreetOther(string message)
        {
            return Content("GreatOther: " + message);
        }

        public ActionResult Serial(string letterCase)
        {
            var serial = "COURSEMVC5ATM1";
            if (letterCase == "lower")
            {
                return Content(serial.ToLower());
            }
            return Json(new { name = "serial", value = serial }, JsonRequestBehavior.AllowGet);
        }

        //Using Atribute Routing:
        //To habilitare atribute routing it is necessary go to RouteCOnfig.cs and put this code there:
        //routes.MapMvcAttributeRoutes();

        //eg. https://blogs.msdn.microsoft.com/webdev/2013/10/17/attribute-routing-in-asp-net-mvc-5/

        // eg: /reviews
        [Route("reviews")]
        public ActionResult Reviews()
        {
            return Content("Index Reviews.");
        }
        // eg: /reviews/5
        [Route("reviews/{reviewId}")]
        public ActionResult Show(int reviewId)
        {
            return Content("Selected ID: " + reviewId);
        }


        //OPTIONAL PARAMETERS:

        // eg: /reviews/5/edit/?
        //[Route("reviews/{reviewId:int}/edit/{name?}")] 
        //other way to do this:
        [Route("reviews/{reviewId:int}/edit/{name=DefaultName}")]
        public ActionResult Edit(int reviewId, string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return Content("Edit ID: " + reviewId);
            }
            return Content("Edit ID: " + reviewId + " Name: " + name);
        }

        /*
         Here, the first route will only be selected if the “id” segment of the URI is an integer. 
         Otherwise, the second route will be chosen.
         // eg: /users/5
        [Route(“users/{id:int}”]
        public ActionResult GetUserById(int id) { … }
 
        // eg: users/ken
        [Route(“users/{name}”]
        public ActionResult GetUserByName(string name) { … }
         */

        /*
         You can apply multiple constraints to a parameter, separated by a colon, for example:
        // eg: /users/5
        // but not /users/10000000000 because it is larger than int.MaxValue,
        // and not /users/0 because of the min(1) constraint.
        [Route(“users/{id:int:min(1)}”)]
        public ActionResult GetUserById(int id) { … }
         */
    }
}