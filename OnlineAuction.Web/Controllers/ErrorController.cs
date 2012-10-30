using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineAuction.Web.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NotFound(string aspxpath)
        {
            return View();
        }

        //public virtual ActionResult ActionResult()
        //{
        //    return RedirectToAction("Index", RouteData.Values);
        //}
    }
}
