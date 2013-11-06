using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PcaSoundCloud.Web.Controllers
{
    public class DefaultController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //if session has token

            //if session has username

            //then
            //ViewBag.Username = filterContext.HttpContext.Session["Username"];

            base.OnActionExecuting(filterContext);
        }
    }
}