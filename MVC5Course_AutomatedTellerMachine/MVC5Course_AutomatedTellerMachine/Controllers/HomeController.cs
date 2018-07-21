using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course_AutomatedTellerMachine.Controllers
{
    public class HomeController : Controller
    {
        //GET /home/index
        public ActionResult Index()
        {
            return View();
        }

        //GET /home/about
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.TheMessage = "Having trouble? Send us a message.";
            return View();
        }

        [HttpPost]
        public ActionResult Contact(string message)
        {
            ViewBag.TheMessage = "Thanks, we got your message!";
            return View();
        }

        public ActionResult Foo()
        {
            ViewBag.Message = "Hello world Rossetti!";
            return View("About");
        }

        public ActionResult Serial(string letterCase)
        {
            var serial = "COURSEMVC5ATM1";
            if(letterCase == "lower")
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