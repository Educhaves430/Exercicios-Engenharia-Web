using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Text.RegularExpressions;

namespace Aula6
{
    public class MyRulesConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if(routeKey != "letter")
            {
                return false; // rejects any other key then "letter"
            }

            // regular expression to validate one character of the presented set
            return values[routeKey] is null || Regex.IsMatch(values[routeKey] as string, @"^[A-ZÂÁÉÓ]$");
        }
    }
}
