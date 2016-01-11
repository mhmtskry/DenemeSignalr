using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DenemesignalR.Areas.Yonetim.Models
{
    public class UserFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = filterContext.HttpContext.Session;
            if (session["Yid"] != null)
                return;

            //Redirect him to somewhere.
            var redirectTarget = new RouteValueDictionary(new { action = "Index", controller = "Giris" });
            filterContext.Result = new RedirectToRouteResult(redirectTarget);

        }
    }
}