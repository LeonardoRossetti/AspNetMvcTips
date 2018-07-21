using MVC5Course_AutomatedTellerMachine.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing;
using System.Web.Routing;

namespace MVC5Course_AutomatedTellerMachine
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapMvcAttributeRoutes();


            var constraintsResolver = new DefaultInlineConstraintResolver();
            constraintsResolver.ConstraintMap.Add("values", typeof(ValuesConstraint));
            routes.MapMvcAttributeRoutes(constraintsResolver);

            
            routes.MapRoute(
                name: "Serial route",
                url: "serial",
                //url: "serial/{letterCase}",
                /*
                 In this case, the parameter 'lowerCase' works as a predefined parameter. In this case I can
                 call the URL like this: http://localhost:63435/Serial/lower
                 But, if I remove the lowerCase parameter here, I still can call the method passing the parameter
                 in this way: http://localhost:63435/Serial?letterCase=lower
                 */
                defaults: new { controller = "Home", action = "Serial"}
                //defaults: new { controller = "Home", action = "Serial", letterCase = "upper" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
