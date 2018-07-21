using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course_AutomatedTellerMachine.Controllers
{
    public class CustomController : Controller
    {
        // GET: Custom
        public ActionResult Index()
        {
            ViewBag.CusomMessage = "Hello woooooooooooooooooooorld!";
            return View();
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
    }


}