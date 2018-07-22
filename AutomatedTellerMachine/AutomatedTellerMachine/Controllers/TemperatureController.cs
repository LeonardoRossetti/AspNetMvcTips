using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutomatedTellerMachine.Controllers
{
    public class TemperatureController : Controller
    {
        // eg: temp/celsius and /temp/fahrenheit and /temp/lalala but not /temp/kelvin
        [Route("temp/{scale:values(celsius|fahrenheit|lalala)}")]
        public ActionResult Show(string scale)
        {
            return Content("scale is " + scale);
        }
    }
}