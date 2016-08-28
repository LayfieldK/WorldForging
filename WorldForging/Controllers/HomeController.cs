using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorldForging.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Worlds()
        {
            return View();
        }

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

        public ActionResult Customer()
        {
            ViewBag.Message = "Customer Section";

            return View();
        }

        public ActionResult Product()
        {
            ViewBag.Message = "Product Section";

            return View();
        }

        public ActionResult Order()
        {
            ViewBag.Message = "Orders Section";

            return View();
        }
    }
}