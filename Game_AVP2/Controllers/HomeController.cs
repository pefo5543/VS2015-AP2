using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Game_AVP2.Controllers
{
    [Authorize]
    public class HomeController : AdminAuthorizationController
    {
        public ActionResult Index()
        {
            return View();
        }
        //[Authorize(Roles = "Admin")]
        //public ActionResult Admin()
        //{
        //    string apiUri = Url.HttpRouteUrl("DefaultApi", new { controller = "Admin", });
        //    ViewBag.ApiUrl = new Uri(Request.Url, apiUri).AbsoluteUri.ToString();

        //    return View();
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}