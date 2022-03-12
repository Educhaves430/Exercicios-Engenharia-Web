using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;

namespace Aula10.Filters
{
    public class DailyMaintenanceFilter : ActionFilterAttribute
    {
        // hours, minutes, seconds
        public int[] From { get; set; }

        public int[] To { get; set; }

        TimeSpan _From, _To;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _From = new TimeSpan(From[0], From[1], From[2]);
            _To = new TimeSpan(To[0], To[1], To[2]);

            TimeSpan _now = DateTime.Now.TimeOfDay;
            if((_From <= _To && _now >= _From && _now <= _To) 
                || (_From > _To && (_now > _From || _now < _To)))
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new { controller = "Security", action = "Maintenance" }
                        )
                    );
            }
            else
            {
                base.OnActionExecuting(context);
            }
        }
    }
}
