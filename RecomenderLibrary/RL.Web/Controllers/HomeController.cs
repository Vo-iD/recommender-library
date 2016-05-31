using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RL.Entity.Own;
using RL.OwnData.Contract.Infrastructure;
using RL.RemoteData.Implementation;

namespace RL.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            var ss = new TestBooks();
            ss.Test();
        }

        public ActionResult Index()
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
    }
}