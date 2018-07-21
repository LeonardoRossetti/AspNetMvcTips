using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace MVC5Course_AutomatedTellerMachine.Classes
{
    public class ValuesConstraint : IRouteConstraint
    {
        private readonly string[] validOptions;
        public ValuesConstraint(string options)
        {
            validOptions = options.Split('|');
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, 
            RouteDirection routeDirection)
        {
            object value;
            if (values.TryGetValue(parameterName, out value) && value != null)
            {
                return validOptions.Contains(value.ToString(), StringComparer.OrdinalIgnoreCase);
            }
            return false;
        }
    }
}